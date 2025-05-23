# 📋 Change Management Plan Template
**Student Name:** Kathy Yost  
**Date Submitted:** May 23, 2025  

---

## 📋 Purpose of Change  
The main issue was that the new "Notes" field for assignments wasn’t working as expected. Notes were missing after saving, and they didn’t show up in the UI or API. Another bug showed completed assignments were still marked as overdue. These issues mattered because users couldn’t trust the data or rely on the app to track important details accurately.

---

## 📋 Summary of Changes  
- Updated the `Assignment` class to store and display the `Notes` property.  
- Fixed the constructor to accept notes properly.  
- Modified `ToString()` to include notes in the printed output.  
- Updated the `IsOverdue()` method to check if the task was already completed.  
- Added new unit tests to validate these changes.  
- Updated `ConsoleUI` so users can enter notes and see them.  
- Added logging using `IAppLogger` to track when assignments are added and when overdue checks are run.

---

## ✅ TDD Process  
- The first test that failed was for checking if notes were saved and returned correctly.  
- I updated the constructor and `ToString()` method, then re-ran the tests.  
- Tests passed after fixing the logic and confirming with multiple scenarios.

---

## 📋 Additional Coverage  
- Tested adding an assignment with empty notes.  
- Verified overdue logic works correctly for both completed and uncompleted tasks.  
- Used logging to confirm that `IsOverdue()` and assignment creation are triggered correctly.

---

## 📋 Challenges  
- GitHub was tricky — the repo was not updating at first.  
- I had to clean the repo, re-link the right files, and reset the remote origin.  
- Also had to make sure `.vs` system files weren’t tracked by Git.  
- Solved it by creating a clean folder, copying the real working files, and pushing again from scratch.

---

## 📋 Recommendations  
- Consider splitting UI from logic even further in future versions.  
- Also, it may help to define a proper DTO model for API separation if this expands.  
- I’d recommend adding edit support for notes in the future and keeping `.vs` files excluded.
