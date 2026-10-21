# GitHub Copilot Instruction File for RimWorld Modding Project

## Mod Overview and Purpose

**Mod Name:** Prisoners Should Fear Turrets  
**Author:** Mlie  
**Description:**  
The "Prisoners Should Fear Turrets" mod enhances the RimWorld experience by adding a feature where escaping prisoners and rebelling slaves will be targeted and fired upon by turrets. This mod allows players to configure targeting behavior through in-game options, providing choices to shoot at slaves and prisoners in any aggressive mental state. Additionally, turrets can impose terror on slaves to help maintain suppression levels. The mod is designed to be compatible with all turrets unless specific turret logic overrides it and also supports the Combat Extended mod.

## Key Features and Systems

- **Targeting Escaping Prisoners:** Turrets will autonomously engage escapees.
- **Configurable Behavior:** Options to target rebelling slaves and prisoners in aggressive mental states.
- **Terror Induction:** Turrets can instill terror in slaves, contributing to ongoing suppression management.
- **Mod Compatibility:** Enhanced compatibility for mods like Combat Extended.
  
## Coding Patterns and Conventions

- **C# File Organization:** The mod is organized into several essential C# files, each fulfilling a specific role:
  - `PawnObserver_ObserveSurroundingThings_TryCreateObservedThought.cs`: Handles postfix logic for observed thoughts.
  - `Building_TurretGun_IsValidTarget.cs`: Contains logic for validating potential targets, with postfix and TargetMethods patterns.
  - `PrisonersShouldFearTurrets.cs`: Main class file for logging and base functionality.
  - `PrisonersShouldFearTurretsMod.cs`: Manages mod settings, initializes UI for configuration.
  - `PrisonersShouldFearTurretsModSettings.cs`: Handles data exposure logic for mod settings.
  
## XML Integration

- **ThoughtDefs Configuration:** XML files are used for defining in-game thoughts, contributing to terror or memory effects. 
  - `Thoughts_Memory_Terror.xml` contains definitions important for implementing the terror effect in gameplay.

## Harmony Patching

- **Harmony Dependency:** Utilizes the `brrainz.harmony` library to apply postfix methods, ensuring the mod code integrates seamlessly with existing game functionality.
- **Patching Strategy:** Postfix methods in critical files such as `PawnObserver_ObserveSurroundingThings_TryCreateObservedThought` and `Building_TurretGun_IsValidTarget` ensure that mod logic modifies vanilla behaviors appropriately without causing conflicts.

## Suggestions for Copilot

When using GitHub Copilot to contribute to this project, consider the following suggestions:

- **Method Signatures:** Ensure new methods and modifications align with existing patterns and conventions in terms of naming and commenting.
- **Documentation:** Include XML documentation comments for all public classes and methods to maintain clarity.
- **Extensibility Considerations:** Design new features with extensibility in mind, making sure they can be easily configured or disabled as needed.
- **Integration Testing:** When implementing new logic, ensure integration with other mod features and ensure compatibility with Combat Extended and other mods.
- **Performance Optimization:** Take care when suggesting logic that may impact performance, such as iterative searches or complex conditional checks within the core game's update cycles.

By following these guidelines, contributions can be made effectively and maintainably, enriching the mod's functionality while preserving game integrity.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

