# Mileage Tracker Console Application

## Overview – Project Aspiration

For this project I aimed to create a simple console based mileage tracker to help me visually see the mileage progression during my cross country season. My goal was to make it easy to view and log my mileage, and I hope to improve it in the future to include future goals and more detailed graphing options. 

---

## Why This Project Is Interesting to Me

This project interests me because as a cross country runner, I want to be able to track and view my mileage progression. This helps me to set goals and track my successes over the season. I also enjoyed connecting the programming concepts into something that I can integrate into my running career, and the challenge that was presented on learning how to graph data in a console application.

---

## Project Scope – What Was Completed

For this submission, I successfully implemented the following features:

- Reading data from a file and loading into a list of a custom class   
- Allowing user input for new mileage and cross-training entries  
- Sorting entries by date  
- Displaying formatted data in the console  
- Creating a ascii character-based graph of mileage values  
- Implementing a menu using switch statements  
- Writing updated data back to the CSV file

Some features, such as advanced graph labeling, input validation beyond basic checks, and deeper automated testing, were only partially explored due to time constraints.

---

## Reflection – What I Learned

Because of this project, I was able to learn and better understand many concepts, such as file reading and writing, switch statements and their uses, and sorting. Sorting was quite a challenge to me, as the data was formatted in a list of a custom class, and I discovered how lambda expressions work. I also learned how to display data in a graphing format within a console application, as well as the limitations and challenges that come from it. This project helped me to better understand the process of the transfomation and display of data. 

---

## Design Diagrams

### Flowchart
    The program follows a simple flow:
    1. Start program
    2. Read mileage data from file
    3. Display menu 
    4. Get user input
    5. Go to selected function
    6. if selected function is "view mileage" or "graph mileage", display information 
        - if user reads key then return to menu
    7. if selected function is "input mileage"
        - get user input for mileage 
        - get user input for cross training
        - return to menu
    8. if selected function is exit, exit the program

---

### Pseudocode

    read data from file
    sort data by date

    display menu
    get user input
    while input is not int
        get user input
        try convert into int

    if choice is view mileage (1)
        display formatted table
        display totals
        if user presses any key
            return to menu
    
    else if choice is input mileage (2)
        get user input
        add entry to list
        write updated list to file
        return to menu
    
    else if choice is graph mileage (3)
        display text-based graph
        if user presses any key
            return to menu
    
    else if choice is exit (4)
        end program

---

### Use-Case Diagram

User sees:
- View mileage data (1)
    - displays data
    - asks for any key to return to menu
- Enter new mileage data (2)  
    - Asks for data
    - Asks for valid number if not provided
    - Returns automatically to menu
- Graph mileage data (3)
    - displays data
    - asks for any key to return to menu
- Exit program (4)

---

## Testing

Basic automated tests were implemented using Debug.Assert to verify that:
- Mileage entries are sorted correctly by date
- Data structures behave as expected when modified

These tests help confirm core logic without requiring user input.

---

## Programming Concepts Used

This project appropriately demonstrates the use of the following concepts:

- Arrays
    - Used to contain data from file initially 
- Lists
    - Used to contain data for input, display, and writing to a file
- Two-dimensional arrays
    - Used to hold data for graphing
- If / else statements
    - Used to validate data, display it correctly, and navigate code correctly
- Switch statements
    - Used to navigate the menu
- Methods
    - Used to simplify the processes held, especially to return to the menu
- While loops
    - Used to validate data such as user input, making sure that the user inputs a correct number
- For loops
    - Used to loop through data for display, file reading, 
- Foreach loops
    - Used to read and write data from the data file
- Reading from a file
    - Used to collect past data
- Writing to a file
    - Used to save data
- String formatting
    - Used for the display of data
- User input
    - Used to change the menu and to write new data
- Lambda expressions
    - Used to sort data by date
- Custom classes
    - Used to contain training data
---

## Conclusion


