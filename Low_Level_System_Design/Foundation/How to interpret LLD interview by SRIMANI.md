# How to interpret LLD interview by Srimani?

---

> *Always keep an eye on the clock to avoid getting stuck in particular area.*
> 

### [BATCH 1] Getting started into the problem statement

- Intro to interviewer
- He will explains the problem statement with functional requirement at high level
- You will analyze and think thru the problem statement and functional requirements
- clarify you understanding
- show them Here use case in this system and identify all main flows needed for requirement
- write down all these requirements in flow wise in .txt/ google docs/ whiteboard

---

### [BATCH 2] Identify all Domain entities

- Identify the domains “core and auxiliary/ supporting entities”
- include only attributes (not methods we can work it out later)
- Make use of ENUMS and BOOLEAN to ensure extensibility.
- use mermaid style class diagram so that we can visualize them easily (if allowed)
- use plain .txt with indentation during interviews for each domain
- identify relationship between domains but mark only FK in domain .txt section. rest all like aggregation, composition you can just highlight

---

### [BATCH 3] Discuss interaction flow for each flow listed on the system

- Visualize the interaction flow on each flow one by one
- use mermaid style sequence diagram so that we can visualize them easily (if allowed)
- Write down interaction in sequence flow manner in plain English for each flow
- Take each flow and highlight potential classes we can have for this system so that it would be easier to resonate at the design time

---

### [BATCH 4] Define system low-level architecture with necessary components (Classes, Abstract Classes, Interfaces, Methods, Enums)

- Start with Architecture level
    - Client/ UI → Controller Layer → Service Layer → Repository Layer → Domain Layer
- Sketch a skeleton like onto the .txt file which basically for packaging / namespacing related classes
    
    
    ```
    Controllers
    ...
    ...
    ...
    Services
    ...
    ...
    ...
    Repositories
    ...
    ...
    ...
    Domains
    ...
    ...
    ...
    DTOs
    ...
    ...
    ...
    ```
    
    ```
    Adapter
    ...
    ...
    ...
    Factory
    ...
    ...
    ...
    Strategy
    ...
    ...
    ...
    // any other packages or namespaces
    // based on the system needs
    ```
    
- Start entering classes and relevant methods for each flow onto the above skeleton which we highlighted during BATCH 3
- Introduce DTOs (Data transfer objects) whenever there’s more than 2 or 3 attributes returned by API / requested by API

---

### [BATCH 5] Walkthrough clean code practices in your system

- Verify the following principles in the skeleton according to the problem statement needs
    - OOP principles like Associate, Aggregation, Composition.
    - SOLID principles
    - DRY, YAGNI, KISS principles
- **Reinforces the design principles and design patterns implemented in your systems to interviewers**

---

### [BATCH 6] Handling edge cases of your current system

- Highlight all edge cases, failure scenarios and system limits of the current system.
- Come up with  solutions for highlighted ones.
- Justify the interviewer that you’ve designed the system which can adopt to these adjustments seamlessly.

---

### [BATCH 7] Discuss the Future Add-ons to your system

- Identify potential future add-ons to the systems
- Justify the extensibility of the system of adding new add-on feature seamlessly to the current system.

---

### [BATCH 8] Define the UML: Class Diagram of your system

- Make use of the “**pre-written skeleton section**” and “**domain entities .txt section**” to come up with class diagram.
- Definitely no choice other than Mermaid class diagram. (my go to option 😎)
- Segregate the class diagram for each flow in the system

---

### [BATCH 9] Machine coding guidelines

- If it is Machine coding round, then go ahead build it with help of “**pre-written skeleton section**”.
- Always develop the codebase flow wise. (Take one flow into your head and stick with it until it was completed from Controller → Domain | Domain → Controller)
- Make use of print lines to simulate the initialization and invocation of sub-steps in a flow.
- Use In-Memory collections as place holder for DB Tables/ Collections.
- Setup Main class (SIMULATION)
    - Construct all repos, services, controllers.
    - Start hitting the end points for each flow with necessary request params.
- Run and demo it to the interviewer.
- Get feedbacks from interviewers for improvements.