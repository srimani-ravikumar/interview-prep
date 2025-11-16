import java.util.*;

// ---------------------------- COMBAT STRATEGY (Strategy Pattern) ----------------------------
interface CombatStrategy {
    // how much extra damage or special effect this strategy applies when attacking
    int executeAttack(Character attacker, Character target);
}

class AggressiveStrategy implements CombatStrategy {
    @Override
    public int executeAttack(Character attacker, Character target) {
        System.out.println(attacker.getName() + " uses Aggressive stance (bonus +5 damage).");
        return 5;
    }
}

class DefensiveStrategy implements CombatStrategy {
    @Override
    public int executeAttack(Character attacker, Character target) {
        System.out.println(attacker.getName() + " uses Defensive stance (no bonus, reduces incoming next hit).");
        // defensive gives no attack bonus; defender gets reduced incoming damage via a flag
        attacker.setTempDefenseBonus(3); // attacker "prepares defense" for next incoming hit
        return 0;
    }
}

// ---------------------------- ABSTRACT CHARACTER ----------------------------
abstract class Character {
    private static int idCounter = 1;

    private final int id;
    private final String name;
    private int health;
    private final int maxHealth;
    private int x, y; // simple 2D position in the world
    private List<String> inventory = new ArrayList<>();
    private CombatStrategy combatStrategy = new AggressiveStrategy(); // default
    private int tempDefenseBonus = 0; // temporary defense reduction for next incoming hit

    public Character(String name, int maxHealth, int startX, int startY) {
        this.id = idCounter++;
        this.name = name;
        this.maxHealth = maxHealth;
        this.health = maxHealth;
        this.x = startX;
        this.y = startY;
    }

    // Encapsulated getters/setters
    public int getId() { return id; }
    public String getName() { return name; }
    public int getHealth() { return health; }
    public int getMaxHealth() { return maxHealth; }
    public boolean isAlive() { return health > 0; }
    public int getX() { return x; }
    public int getY() { return y; }
    public List<String> getInventory() { return Collections.unmodifiableList(inventory); }

    public void setCombatStrategy(CombatStrategy s) {
        this.combatStrategy = s;
        System.out.println(name + " switched strategy to " + s.getClass().getSimpleName());
    }

    public void setTempDefenseBonus(int b) { this.tempDefenseBonus = b; }
    public int consumeTempDefenseBonus() {
        int b = this.tempDefenseBonus;
        this.tempDefenseBonus = 0;
        return b;
    }

    // movement (abstraction)
    public void move(int dx, int dy) {
        if (!isAlive()) {
            System.out.println(name + " cannot move (dead).");
            return;
        }
        this.x += dx;
        this.y += dy;
        System.out.println(name + " moved to (" + x + "," + y + ").");
    }

    // polymorphic attack: subclasses provide baseDamage and special behaviour
    public void attack(Character target) {
        if (!isAlive()) {
            System.out.println(name + " can't attack (dead).");
            return;
        }
        if (!target.isAlive()) {
            System.out.println(target.getName() + " is already down.");
            return;
        }

        int base = baseDamage();
        int stratBonus = combatStrategy.executeAttack(this, target);
        int totalDamage = base + stratBonus;

        // class-specific effects
        totalDamage += classSpecificAttackEffect(target);

        System.out.println(name + " attacks " + target.getName() + " dealing " + totalDamage + " damage.");
        target.defend(totalDamage);
    }

    // defense reduces damage; subclasses can override for shields, armor, etc.
    public void defend(int incomingDamage) {
        int defense = consumeTempDefenseBonus();
        int finalDamage = Math.max(0, incomingDamage - defense);
        this.health -= finalDamage;
        System.out.println(name + " defends with " + defense + " block, receives " + finalDamage + " damage. (HP: " + Math.max(0, health) + "/" + maxHealth + ")");
        if (this.health <= 0) {
            onDeath();
        }
    }

    // pick up item
    public void pickUp(String item) {
        inventory.add(item);
        System.out.println(name + " picked up: " + item);
    }

    // heal / use potion
    public void useItem(String item) {
        if (!inventory.contains(item)) {
            System.out.println(name + " doesn't have " + item);
            return;
        }
        if (item.equalsIgnoreCase("Health Potion")) {
            int heal = 30;
            this.health = Math.min(maxHealth, this.health + heal);
            inventory.remove(item);
            System.out.println(name + " used Health Potion. Healed " + heal + ". (HP: " + health + "/" + maxHealth + ")");
        } else {
            System.out.println(name + " used " + item + ". (No effect implemented.)");
            inventory.remove(item);
        }
    }

    // hooks / abstract methods subclasses must implement
    protected abstract int baseDamage();
    protected abstract int classSpecificAttackEffect(Character target);
    protected abstract void onDeath();

    @Override
    public String toString() {
        return "[" + id + "] " + name + " HP:" + health + "/" + maxHealth + " Pos:(" + x + "," + y + ")";
    }
}

// ---------------------------- CHARACTER TYPES ----------------------------
class Warrior extends Character {
    public Warrior(String name, int x, int y) {
        super(name, 150, x, y);
    }

    @Override
    protected int baseDamage() {
        return 20; // melee base
    }

    @Override
    protected int classSpecificAttackEffect(Character target) {
        // Warrior has 20% chance to do a heavy strike (+10)
        if (new Random().nextInt(100) < 20) {
            System.out.println(getName() + " performs a heavy strike! (+10)");
            return 10;
        }
        return 0;
    }

    @Override
    protected void onDeath() {
        System.out.println(getName() + " (Warrior) has fallen in battle!");
    }
}

class Mage extends Character {
    private int mana = 100;

    public Mage(String name, int x, int y) {
        super(name, 100, x, y);
    }

    @Override
    protected int baseDamage() {
        // mage uses mana for magic shots; if insufficient mana, low base damage
        if (mana >= 20) {
            mana -= 20;
            System.out.println(getName() + " casts a spell (-20 mana). Mana left: " + mana);
            return 30;
        } else {
            System.out.println(getName() + " is low on mana; weak hit.");
            return 8;
        }
    }

    @Override
    protected int classSpecificAttackEffect(Character target) {
        // mage can apply burn that deals +5 immediate damage sometimes
        if (new Random().nextInt(100) < 25) {
            System.out.println(getName() + "'s spell burns the target (+5).");
            return 5;
        }
        return 0;
    }

    @Override
    protected void onDeath() {
        System.out.println(getName() + " (Mage) collapsed in arcane energy!");
    }
}

class Archer extends Character {
    public Archer(String name, int x, int y) {
        super(name, 110, x, y);
    }

    @Override
    protected int baseDamage() {
        // archer has ranged damage; bonus if distance > 1
        return 18;
    }

    @Override
    protected int classSpecificAttackEffect(Character target) {
        // critical chance based on distance
        int dx = Math.abs(getX() - target.getX());
        int dy = Math.abs(getY() - target.getY());
        int dist = Math.max(dx, dy);
        if (dist >= 2 && new Random().nextInt(100) < 30) {
            System.out.println(getName() + " lands a long-range critical (+12)!");
            return 12;
        }
        return 0;
    }

    @Override
    protected void onDeath() {
        System.out.println(getName() + " (Archer) has been taken down!");
    }
}

// ---------------------------- GAME WORLD (shared environment) ----------------------------
class GameWorld {
    private List<Character> characters = new ArrayList<>();
    private int tickCount = 0;

    public void addCharacter(Character c) {
        characters.add(c);
        System.out.println("Spawned: " + c);
    }

    public void removeDead() {
        characters.removeIf(c -> !c.isAlive());
    }

    public Character findNearestEnemy(Character by) {
        Character best = null;
        double bestDist = Double.MAX_VALUE;
        for (Character c : characters) {
            if (c == by || !c.isAlive()) continue;
            // naive: everyone is enemy to everyone for this demo
            double dist = Math.hypot(c.getX() - by.getX(), c.getY() - by.getY());
            if (dist < bestDist) {
                bestDist = dist;
                best = c;
            }
        }
        return best;
    }

    // simple tick: each alive char moves randomly a bit and attacks nearest if in range
    public void tick() {
        tickCount++;
        System.out.println("\n=== World Tick #" + tickCount + " ===");
        // shuffle to avoid ordering bias
        Collections.shuffle(characters);

        for (Character c : new ArrayList<>(characters)) {
            if (!c.isAlive()) continue;

            // random move (small)
            int dx = new Random().nextInt(3) - 1; // -1,0,1
            int dy = new Random().nextInt(3) - 1;
            c.move(dx, dy);

            Character enemy = findNearestEnemy(c);
            if (enemy != null) {
                // if within attack range (distance <=2) attack; else maybe move towards
                double dist = Math.hypot(enemy.getX() - c.getX(), enemy.getY() - c.getY());
                if (dist <= 2.0) {
                    c.attack(enemy);
                } else {
                    // move one step towards enemy
                    int stepX = Integer.compare(enemy.getX(), c.getX());
                    int stepY = Integer.compare(enemy.getY(), c.getY());
                    c.move(stepX, stepY);
                    System.out.println(c.getName() + " closes distance to " + enemy.getName());
                }
            } else {
                System.out.println(c.getName() + " waits (no enemies).");
            }
        }

        removeDead();
    }

    public void showStatus() {
        System.out.println("\n--- World Status ---");
        for (Character c : characters) {
            System.out.println(c);
        }
        System.out.println("--------------------");
    }
}

// ---------------------------- SIMULATION (MAIN) ----------------------------
public class GameApp {
    public static void main(String[] args) throws InterruptedException {
        System.out.println("🌍 Arcadia Realm — Simulation Start\n");

        GameWorld world = new GameWorld();

        // Srimani joins as a Warrior
        Character srimani = new Warrior("Srimani", 0, 0);
        srimani.pickUp("Health Potion");
        srimani.pickUp("Iron Sword");

        // Friends / enemies
        Character archer = new Archer("Aditi", 3, 2);
        Character mage = new Mage("Kiran", -2, -1);
        Character orc = new Warrior("Orc Grunt", 5, 5); // enemy NPC warrior

        world.addCharacter(srimani);
        world.addCharacter(archer);
        world.addCharacter(mage);
        world.addCharacter(orc);

        // Srimani chooses Aggressive strategy
        srimani.setCombatStrategy(new AggressiveStrategy());
        // Aditi prefers Defensive
        archer.setCombatStrategy(new DefensiveStrategy());
        // Kiran the mage stays aggressive (default)

        world.showStatus();

        // Run several ticks of the world
        for (int i = 0; i < 6; i++) {
            world.tick();
            Thread.sleep(600); // simulate time passage (short)
            // srimani uses a potion if health low
            if (srimani.isAlive() && srimani.getHealth() < 60) {
                srimani.useItem("Health Potion");
            }
            world.showStatus();
        }

        System.out.println("\n🏁 Simulation ended. Final world state above.");
    }
}