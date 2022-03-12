# TimeKeeper
A simple hour tracker eventually intended for use by the FRC robotics team I mentor.


---

# TODO: 
- [X] Finish  TUI for testing
- [X] Write fucntion to read saved user data from JSON file
      <br> ~This is currently really broken, and I don't know why. Deserialize keeps crashing.~
      <br>  Nevermind I fixed it.  Apparently Deserialize requires access to a constructor with no parameters.
- [X] Save user data to JSON file
- [X] Write function to get hours
- [ ] Write GUI