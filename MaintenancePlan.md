# Maintenance Plan

## Goals
To ensure the ongoing quality, stability, and usability of the Assignment Management System through regular updates, code reviews, and documentation practices.

## Schedule
- ✅ **Quarterly Code Reviews**: Review for code quality, performance, and architectural improvements.
- ✅ **Biweekly Bug Triage**: Review open issues and assign priorities.
- ✅ **Monthly Dependency Check**: Update NuGet packages and project dependencies.

## Code Quality Practices
- Use Visual Studio’s Code Metrics to identify complex or tightly coupled code.
- Refactor any method with a cyclomatic complexity greater than 10.
- Keep methods short and single-responsibility.
- Document new classes/methods using XML comments.

## Testing
- Maintain at least **80% unit test coverage**.
- Ensure every bug fix includes a **regression test**.
- Use **Moq** and **xUnit** to isolate logic for service-level testing.

## Documentation
- Update the `README.md` after every major change.
- Keep `DeveloperNotes.txt` updated with important technical decisions.
- Ensure `ChangeManagementPlan.md` reflects recent fixes.

## GitHub Workflow
- Use feature branches for major changes.
- Submit pull requests with clear descriptions.
- Link PRs to relevant issues or features.
- Delete merged branches to keep the repo clean.


