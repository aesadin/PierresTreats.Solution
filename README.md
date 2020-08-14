**<h1 align = "center"> Pierre's Bakery**




**<h2 align="center">Sweet or Savory**


**<h4 align = "center">
  <a href="#requirements">Requirements</a> •
  <a href="#setup">Setup</a> •
  <a href="#protecting-your-data">Protecting Data<a> •
  <a href="#questions-and-concerns">Q's & C's</a> •
  <a href="#technologies-used">Technologies</a> •
  <a href="#bugs">Bugs</a> •  
  <a href="#contributors">Contributors</a> •
  <a href="#license">License</a>**

<br>
<h2 align = "center">
</h1>

**ABOUT**

An application that allows the user to create a list of engineers and a list of machines. The user may assign machines to engineers who are licensed to work on them. The user may add and delete both machines and engineers. 


## **REQUIREMENTS**

* Install [Git v2.62.2+](https://git-scm.com/downloads/)
* Install [.NET version 3.1 SDK v2.2+](https://dotnet.microsoft.com/download/dotnet-core/2.2)
* Install [Visual Studio Code](https://code.visualstudio.com/)
* Install [MySql Workbench](https://www.mysql.com/products/workbench/)

 ## **SPECIFICATIONS**

1. **Behavior:** The user is welcomed with a splash page and given the option to view Machines or view Engineers.
* **Input Example:** "View Machines" or "Add a new Machine"
* **Output Example:** /Machines or /Engineers 

2. **Behavior:** When the user navigates to "View Machines" a list of all Machines will be displayed, if there are no Machines the message "There are currently no Machines listed" and given the option to "Add a Machine".
* **Input Example:** "Add a Machine"
* **Output Example:** /Machines/Create

3. **Behavior:** If the user navigates to "Add a Machine" the program will allow the user to add a new Machine and then be directed to Machines.
* **Input Example:** "Add new Machine"
* **Output Example:** /Machines

4. **Behavior:** The program will allow the user to click on a Machine.
* **Input Example:** "Vending Machine"
* **Output Example:** /Machines/Details/{MachinesId}

5. **Behavior:** The program will allow the user to view all Engineers.
* **Input Example:** "View Engineers"
* **Output Example:** /Engineers

6. **Behavior:** The program will allow the user to add a new Engineer to a specific Machine.
* **Input Example:** "Add an Engineer"
* **Output Example:** /Engineers/Create

7. **Behavior:** The program will allow the user to view Engineer details.
* **Input Example:** "Allison Sadin"
* **Output Example:** /Engineers/Details/{EngineersId}

8. **Behavior:** The program will allow the user to edit Engineer details.
* **Input Example:** "Edit This Engineer"
* **Output Example:** /Engineers/Edit/{EngineersId}

9. **Behavior:** The program will allow the user to edit Machine details.
* **Input Example:** "Edit This Machine"
* **Output Example:** /Machines/Edit/{MachinesId}

10. **Behavior:** The program will allow the user to delete Machine details.
* **Input Example:** "Delete This Machine"
* **Output Example:** /Machines/Delete/{MachinesId}

10. **Behavior:** The program will allow the user to delete Engineer details.
* **Input Example:** "Delete This Engineer"
* **Output Example:** /Engineers/Delete/{EngineersId}


<br>



## **SETUP**

* _Install and configure MySQL_
  1. _This program utilizes MySQL Community Server version 8.0.15 and requires [this to be pre-installed](https://dev.mysql.com/downloads/file/?id=484914). Click the link at the bottom that reads "No thanks, just start my download"_
  2. _Use Legacy Password Encryption and set password to "epicodus"_
  3. _Click "Finish_

copy this url to clone this project to your local system:
```html
https://github.com/tmemmerson/Sneuss.Solution.git
```

<br>

Once copied, select "Clone Repository" from within VSCode & paste the copied link as shown in the image below.

![cloning](https://coding-assets.s3-us-west-2.amazonaws.com/img/clone-github2.gif "Cloning from Github within VSCode")

<br>

* _Install the MySQL database_
  1. _Open a new terminal in your text editor (Ctrl+\` in V.S. Code) and run command `> echo 'export PATH="$PATH:/usr/local/mysql/bin"' >> ~/.zprofile`_
  2. _Enter the command `> source ~/.zprofile` to confirm MsSQL has been installed_
  3. _Connect to MySQL by running the command `> mysql -uroot -pepicodus`_
  4. _Install the necessary MySQL database by copying the code block from the .sql file and entering it into your terminal OR import the 'allison_sadin.sql' file included in the repo to MySQL workbench_
  5. _Once the code block has been entered or the file imported, you will close MySQL by running the command `> exit`_


<br>

* _Run the application_
  1. _In the terminal, navigate to the project directory by running the command `> cd TheTreats`_
  2. _Now that we are in the PierresTreats directory you will run the command `> dotnet restore`_
  3. _Once the "obj" folder has initialized you will run the command `> dotnet run`_
  4. _Go to http://localhost:5000/ in your preferred browser to use the application_

![cloning](https://coding-assets.s3-us-west-2.amazonaws.com/img/dotnet-readme.gif "How to clone repo")


## **🔧PROTECTING YOUR DATA**

#### **Step 1: From within VSCode in the root project directory, we will create a .gitignore file**

# For Mac Users
```js 
touch .gitignore 
```

# For Windows Users:

```js 
ni .gitignore 
```

#### Step 2: commit that .gitignore file (this prevents your sensitive information from being shown to others). **⚠️DO NOT PROCEED UNTIL YOU DO!⚠️**

![setup](https://coding-assets.s3-us-west-2.amazonaws.com/img/entity-readme-image.png "Set up instructions")

#### Step 3: **To commit your .gitignore file enter the following commands**

```js
git add .gitignore
```
```js
git commit -m "protect data"
```

#### Step 4: **Then, you need to update your username and password in the appsettings.json file.**

_by default these are set to user:root and an empty password. if you are unsure, refer to the settings for your MySqlWorkbench._

![appsettings](https://coding-assets.s3-us-west-2.amazonaws.com/img/app-settings.png)

<br>

## **QUESTIONS AND CONCERNS**

_Questions, comments and concerns can be directed to the author Allison Sadin aesadin@gmail.com_

<br>

## **Technologies Used**

_**Written in:** [Visual Studio Code](https://code.visualstudio.com/)_

_**Image work:** [Adobe Photoshop](https://www.adobe.com/products/photoshop.html/)_

_**Database Mgmt:** [MySql Workbench](https://www.mysql.com/products/workbench/)_

_**Language:** [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)_

<br>


## **Known Bugs**

_**No known bugs**_

<br>


## **Contributors**


[<img src="https://coding-assets.s3-us-west-2.amazonaws.com/linked-in-images/allison-sadin.jpg" width="160px;"/><br /><sub><b>Allison Sadin</b></sub>](https://www.linkedin.com/in/allison-sadin-pdx/)<br /> 


<br>

## **License**
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Copyright (c) 2020 **_Allison Sadin_**