This README is a clear Docummentation of the project at hand.


Introduction:
STEMify Edu App is a web-based educational application designed to help young learners engage with STEM (Science, Technology, Engineering, and Mathematics) content through interactive courses, quizzes ready available online resources. The platform aims to make learning interactive and trackable, allowing students to practice STEM topics in an interactive way. 
This documentation provides a comprehensive overview of the STEMify Edu App, including its objectives, target users, features, and technical implementation details. It is written in a formal yet easy to understand language, and suitable as a technical reference. Readers will gain insight into how the application is structured, how to install and run it, the roles and use-cases it supports.
Project Objectives
The STEMify Edu App was developed with several key objectives in mind:
Enhance STEM Learning: Provide an engaging platform for young learners to improve their understanding of STEM subjects through interactive content (courses, quizzes, etc.).
Interactive Quizzing: Enable students to take quizzes on various topics, receiving immediate feedback and scores to reinforce learning.
Progress Tracking: Track each student’s progress (e.g. quizzes taken, scores) so that users can monitor improvement over time.
Content Management: Allow administrators and educators to easily create and manage educational content such as courses and quiz questions without needing technical expertise.
Multi-Role Access: Support different user roles (such as students, teachers, parents, and admins), with appropriate permissions for each. For example, teachers/parents should be able to view student progress, while admins can manage the system’s content and users.
User-Friendly Interface: Provide a clean, intuitive user interface that is age-appropriate for young users and simple for parents/teachers to navigate.


By achieving these objectives, the project aims to demonstrate good software process practices (requirements analysis, design, implementation and testing.) in the context of a real-world education app.
Target Audience
The STEMify Edu App is designed with a primary and secondary audience in mind:
Primary Users – Students: The main users are young learners (e.g. in primary or secondary school) who use the app to learn and practice STEM topics. The content and interface are tailored to be engaging and appropriate for children (with gamified elements like quizzes, scores, and basic progress stats). These users interact with the app by taking quizzes, viewing course materials, and checking their own progress.


Secondary Users - System Admins and Educators: Although not the learning target, these user categories are responsible for managing the application. They handle tasks like adding new content (courses/quizzes), managing user accounts, and overseeing the system’s operation. Administrators ensure the app content stays updated and appropriate for the students. In a school setting, an IT facilitator or lead teacher might act as an administrator for the platform.
By catering to these audiences, STEMify ensures that students have quality educational content, while educators have the oversight tools needed to guide the learning process. Each user group has specific interfaces and features tailored to their needs, as detailed in the use cases section.
Key Features
The STEMify Edu App includes the following key features and functionalities:
User Registration and Authentication: Users can register for an account and log in to the app. The system uses secure authentication (ASP.NET Identity) with support for role-based access control. New users by default register as regular students. Credentials are stored securely, and features like password rules (minimum length, required characters) are enforced for security. An “Admin” user role is seeded by default to manage the system.


Role-Based Access & Profiles: The app defines three main user roels which are: Admin, User, and educator. Administrators have full access to manage content and users, while regular users (students) have access to learning materials. The educator role (intended for educators) could be used to allow teachers to create or edit content without full admin rights. User profiles contain basic information (username, email) and a dashboard.


Courses Management: Administrators/Editors can create and manage Courses – which are essentially groupings of educational content. Each course has attributes like a name, description, category (subject area), difficulty level, and a unique code. The app provides interfaces to create new courses, define their category and difficulty, edit details, and mark courses active/inactive. This modular structure allows content to be organized in a meaningful way for students (for example, a course could be “Introduction to Java” under category Technology, difficulty Beginner).


Quiz Creation and Management: A core feature is the ability to create and administer quizzes. Quizzes consist of a set of questions on a specific topic (often a quiz might be associated with a course or subject). Admins (or educators/teachers) can add new quizzes by providing a title and then adding questions to the quiz. The system supports multiple question types:


Multiple Choice Questions – where a student selects an answer from provided options (A, B, C, D). The quiz creator can specify the options and the correct answer.


Fill-in-the-Blank Questions – where the question is a statement with a missing term that the student must fill in. A correct answer string is provided by the creator/educator.


True/False Questions – where the student simply answers whether a given statement is true or false.



Taking Quizzes (Student Experience): A student user can take a quiz by navigating to it (for example, via the list of quizzes or courses). When taking a quiz, the questions are presented one by one or as a form (depending on UI implementation). The student submits answers, and the app evaluates the responses. At the end of the quiz, a Quiz Result is generated, showing the score (e.g., number of correct answers out of total). The result is saved to the database for progress tracking. The interface provides feedback on which questions were answered correctly or incorrectly.

Progress Tracking and Dashboard: Each time a student takes a quiz, the outcome is recorded in a QuizResult object containing the score and timestamp. This allows the system to keep a history of performance. The home page (after login) acts as a dashboard, showing some key stats for the logged-in student – for example, the number of quizzes passed, the fastest quiz completion time, and total correct answers. There is also a list of available courses for the student to explore.


User and Role Management: Aside from content, managing who can access the system is crucial. The app allows admins to view the list of user accounts, create new roles, and assign roles to users. For instance, an admin can promote a regular user to an educator (teacher) role or create a new role if needed. There are dedicated pages for viewing all roles, creating a role, and viewing users with their roles. By default, the roles Admin, User, and educator are created during initial seeding. The admin user has both Admin and User roles by default, ensuring they have full access to all features. Role management is important for controlling access (for example, certain pages like content creation or role assignment pages should only be visible to Admins).


Responsive UI with Bootstrap: The front-end uses Bootstrap to ensure the site is responsive and mobile-friendly. The layout adjusts to different screen sizes, which is important since students might access the app from tablets or small laptops. Common UI components (navigation bar, forms, buttons) use Bootstrap styles for a consistent and modern look.


Data Persistence and Integrity: All persistent data – user accounts, courses, quizzes, questions, and results – are stored in a SQL Server database. The application uses Entity Framework Core (EF Core) as an Object-Relational Mapper (ORM) to handle database operations. Data models are defined for each entity (User, Course, Quiz, QuizQuestions, etc.), and EF Core ensures the database schema matches these models. This makes data access robust and secure, while abstracting away SQL queries in the code. Additionally, the app includes initial database migrations for setting up the schema (including tables for Identity and our domain models). Identity management ensures password hashing and user uniqueness to maintain data integrity for user info.


Security Features: Besides role-based access control, the app enforces some basic security best practices. For example, it requires confirmed email for login by default (though this can be toggled), strong passwords (minimum length 8 with a mix of characters), and uses anti-forgery tokens on form submissions (ASP.NET Core’s default for forms, which is visible in the code decorating POST actions, e.g., [ValidateAntiForgeryToken] on controller methods). These measures protect against common web vulnerabilities like cross-site request forgery (CSRF). Also, sensitive configuration like database connection strings are kept in a configuration file (appsettings.json) rather than hard-coded, and would normally be secured in a production environment.


These features collectively provide a full-fledged learning platform. While the current version is a prototype (some features like detailed progress analytics are none existent), the architecture supports extending each of these areas. For instance, more quiz question types or gamification elements can be added without drastic changes to the system design.
System Architecture
Multi-Tier Architecture: The STEMify Edu App follows a client–server architecture organized into multiple layers. On the client side, users interact with the system through a web browser interface (the presentation layer). The server side is built on ASP.NET Core MVC, which acts as the application layer handling the business logic and communications. Underlying this is the data layer, consisting of a SQL Server database that stores all persistent data (both application data and user identity data).
MVC Structure: The server application is structured following the Model-View-Controller (MVC) pattern.
Models represent the data structures or entities (such as Course, Quiz, Question, User, QuizResult, etc.), typically mapped to database tables via Entity Framework. They also include any logic for data validation (via annotations) or relationships between entities.


Views are the front-end pages (Razor .cshtml files) that render HTML/CSS for the browser. They use Bootstrap for layout and styling. Views display data passed to them by controllers and provide forms for user input (e.g., forms for creating a quiz or answering a quiz).


Controllers handle incoming HTTP requests, interact with the data through models (often via a data access layer), and then select an appropriate view to render the response. For example, the QuizController contains actions to list quizzes, show a form to add a quiz, handle quiz creation submissions, and so on.


Data Access Layer: To keep the code organized, STEMify uses the Repository and Unit of Work patterns for data access. There are repository classes for each aggregate (e.g., QuizRepository, QuizQuestionRepository, CourseRepository, etc.) and an IUnitOfWork interface that aggregates all repositories and manages database save operations. The AppDbContext (EF Core DbContext) is the central point for database interactions; it’s configured to use SQL Server with a connection string in the configuration. When a controller needs to fetch or modify data, it calls methods on the UnitOfWork (which delegates to the appropriate repository). This makes direct EF Core calls and makes it easier to manage database transactions. For example, adding a new quiz question might involve creating a QuizQuestion entity and possibly a related MultipleChoiceQuestion entity; using a UnitOfWork ensures both are saved together or rolled back on failure.
Identity and Security Architecture: The app uses ASP.NET Core Identity for authentication and authorization. A separate ApplicationDbContext (Identity DbContext) is configured for membership data (storing users, roles, password hashes, etc.). On startup, the system seeds default roles and an admin user using the Identity APIs. Identity is integrated with the app’s cookie-based authentication, so when a user logs in, an authentication cookie is issued, and their role claims are used to restrict access to certain controller actions (e.g., only Admins can access the Role management pages). The architecture cleanly separates this security concern: Identity code (managing users/roles) are mostly in the AccountController and RolesController, as well as in the startup configuration, while domain logic (courses/quizzes) is handled in separate controllers. This modular approach follows good security design – minimal and necessary coupling between the user management system and the main application features.
Database Design: The underlying SQL database has tables corresponding to the models. Key tables include:
AspNetUsers, AspNetRoles, AspNetUserRoles (etc.): These are the default Identity tables for user accounts and roles.


Courses, Categories, DifficultyLevels: store course info and reference data for categories and difficulty levels.


Quizzes, QuizQuestions, QuestionTypes: store quizzes and their questions. QuestionTypes might define an enum or id for “Multiple Choice”, “True/False”, etc.


MultipleChoiceQuestions, FillInTheBlankQuestions, TrueFalseQuestions: separate tables for details specific to those question types (each linked via a foreign key to a base QuizQuestion entry).


QuizResults, UserAnswers: tables recording quiz attempts by users and their answers for each question.


The use of EF Core Code architecture ensures that any changes to models can be migrated to the database incrementally without losing data (for example, adding a new field to QuizResult would be done through a new EF migration script or a direct sql query script).
External Integration: The current architecture is self-contained (all functionality and data storage are within the application and its database). However, the design allows integration with external services in the future. For example, if one wanted to add an email service to notify users of new content, that could be added in the service layer without affecting models or views. Similarly, the database could be swapped for another relational DB (or even a cloud NoSQL service) by changing the EF Core provider configuration, 
In summary, the architecture is a classic three-tier design with clear separation of concerns:
Presentation Layer: Browser-based UI (HTML/CSS/JS) generated by ASP.NET Views.


Application Layer: ASP.NET Core MVC application (Controllers, Services, Business Logic, Identity).


Data Layer: EF Core (Repositories/UnitOfWork) and SQL Server database.


This structure makes the STEMify app maintainable and scalable. New features can be added by extending the appropriate layer (e.g., new pages(Views) and controllers for new user stories, new models and migrations for new data needs) without monolithic changes to the entire system.
Technologies Used
The development of STEMify Edu App leverages a modern technology stack and several frameworks/libraries. Below is an overview of the technologies and tools used:
Programming Language & Framework: The application is built with C# using .NET 8 (ASP.NET Core). In particular, it uses ASP.NET Core MVC, which provides the Model-View-Controller structure and the foundational web framework. The project targets .NET 8.0 in the current build (as indicated by the project files), ensuring access to the latest C# features and performance improvements.


Web Application Framework: ASP.NET Core MVC is used for handling web requests and responses. It provides the routing system, controller infrastructure, Razor view engine for generating HTML, model binding, and more. This framework was chosen for its robustness and built-in features like Identity, validation, and ease of deploying to web servers or cloud.


Database and ORM: Microsoft SQL Server Management System is used as the primary database for persistence. During development, a local SQL Express or LocalDB can be used, and in production an Azure SQL Database was configured (connection strings for both are present in appsettings.json).


Front-End Libraries: The user interface is built using HTML5/CSS3 and JavaScript, with most use of the Bootstrap 5 framework for responsive design and styling. Bootstrap provides the layout grid (used for the course listing and form layouts) and pre-styled components (like navigation bar, buttons, form controls). The consistent green color theme in the app (as seen in headings and course cards) was achieved by customizing Bootstrap components. For interactivity and DOM manipulation, jQuery was  included. Additionally, jQuery Validation and jQuery Validation Unobtrusive libraries are referenced for client-side form validation. These ensure that, for example, when an admin tries to submit a new quiz question form, any missing required fields will be highlighted immediately on the page. The combination of Bootstrap and jQuery means the app uses proven, widely-used front-end technologies to ensure cross-browser compatibility and a smooth user experience.


Development Tools: Development was done using Visual Studio 2022 with the .NET CLI. The solution includes the main web application project. Standard tools like the C# compiler (Roslyn) and MSBuild are used (implicitly through the .NET SDK) to build the project. Source control with Git was used.


Libraries and Packages: In addition to the core frameworks, a few NuGet packages are required:


Microsoft.AspNetCore.Identity.EntityFrameworkCore – This is for Identity and EF Core integration.


Microsoft.EntityFrameworkCore.SqlServer – This is the Entity Framework Core database provider for SQL Server.


Microsoft.EntityFrameworkCore.Tools – For initial migrations and related design-time tools.


Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore – For showing detailed DB errors in development.



Platform: The application is cross-platform thanks to .NET Core. It can run on Windows, Linux, or macOS. The use of .NET 8 (Core) means deployment could be on an IIS web server, Azure App Service, or a Docker container. The database being SQL Server suggests production use on Windows or Azure SQL, but EF Core could allow using a different database if needed with minimal changes.


In summary, STEMify’s implementation stands on a solid combination of Microsoft’s ASP.NET stack for the backend and popular open-source libraries for the frontend. This mix was chosen to satisfy the requirements of being robust (in terms of performance), familiar to developers, and providing a good user experience out-of-the-box. All these technologies work in contrast to provide the functionality described in the Features section.
Installation and Setup Instructions
To set up and run the STEMify Edu App on a local development machine or a server, follow these steps:
Prerequisites: Ensure you have the .NET SDK installed . You also need a SQL Server instance or LocalDB for the database. We recommend using Visual Studio, the Community Edition 2022 or later is recommended, which comes with the required SDK and LocalDB. Otherwise, the .NET Core CLI (dotnet) is needed for command-line build and run.


Obtain the Source Code: Download or clone the project’s source code. The solution is named Software-Processes-2025, containing a project named STEMify.


Database Configuration: Open the appsettings.json file in the project’s directory. In the ConnectionStrings section, you will find two connection strings – one for DefaultConnection (used for Identity) and one for AppConnection (used for the application data). By default, these are pointing to an Azure SQL Database instance (with placeholders for credentials). For local setup, you should modify these to point to your local SQL Server. For example, you can use a LocalDB connection string such as:

 json
CopyEdit
"DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=STEMifyAuth;Trusted_Connection=True;",
"AppConnection": "Server=(localdb)\\MSSQLLocalDB;Database=STEMifyMain;Trusted_Connection=True;"
Make sure the User ID and Password fields (if any) correspond to your SQL credentials or remove them if using integrated security. This step is important to ensure the app can connect to a database. Note: If you prefer not to set up SQL Server, an alternative is to change the database provider to SQLite (by installing the Microsoft.EntityFrameworkCore.Sqlite package and changing UseSqlServer to UseSqlite in Program.cs), but that is an advanced alteration; the default expectation is SQL Server.


Restore Dependencies: If using Visual Studio, opening the solution will automatically restore NuGet packages. If using command line, navigate to the project directory and run dotnet restore. This will download all necessary libraries.


Database Initialization: Before running the app, you need to ensure the database is created and the schema is in place. The project includes EF Core migrations (for example, the initial create migration is present). You have two options:


Automatic: The database is available per request.


Manual Script: Alternatively, use SQL Server Management Studio to execute the migration script or simply run the application and let it fail to connect, then inspect the error for a generated script. The easier method is the CLI though.



Seeding Initial Data: The first time the application runs, it will seed some initial data into the database. Specifically, it creates the default roles (Admin, User, educator) and an initial administrator account. The seeding logic is in SeedData.Initialize() which is invoked during startup with a default admin password. In the code, the default admin credentials are:


Username: admin@stemify.com


Password: YourAdminPassword123! (The string "YourAdminPassword123!" is used in the seeding call – you may change this before running the app for better security.)


Additionally, a regular user account is seeded:


Username: user@stemify.com


Password: UserPassword123! (this is the default provided in the source code for regular user seeding).


Both accounts will have their emails marked as confirmed (so you can log in without any email verification flow)*NB: MAIL SERVICE NOT IMPLEMENTED YET. The admin account is added to both the Admin and User roles, while the regular user is added to the User role. Note: These credentials are for initial development/testing convenience. It is strongly recommended to change the admin password to something secure after first login, and obviously, in a production scenario, seeding a known password is not advised.


Running the Application: You can now run the app.


In Visual Studio, set STEMify as the startup project and press F5 (Debug) or Ctrl+F5 (Run without debugging). This will build the project and launch it on the local web server (Kestrel or IIS Express).


Using CLI, navigate to the project folder and run dotnet run. The console will indicate that the application has started and listening on a URL (by default something like https://localhost:5001).


Once running, open a web browser and navigate to the URL (e.g., http://localhost:5000 or the HTTPS endpoint). You should see the home page of STEMify Edu App.


Using the Application:


Navigate to the Register page on the top right of the landing page. Create a new account if you want to test as a student, or use the seeded accounts. To log in as administrator, use the admin credentials specified above.


After logging in, you should be taken to the home dashboard. Here, if you logged in as admin@stemify.com, you effectively have admin rights. You can navigate to the Courses section (perhaps via a link or by going to /Course URL) to add/view courses. You can go to Quizzes section (e.g., /Quiz) to add quizzes and questions.


The admin interface will have options like “Add Quiz”, “Add Question”, etc. Try creating a sample course and a quiz under it with a couple of questions to ensure everything is working. After creating quizzes, log out and log in as the regular user (user@stemify.com) to attempt the quiz and see the result recording.


The Roles management pages (if linked in a nav menu or accessible via /Roles) will allow you to see existing roles and assign users to roles. For example, you can assign the user@stemify.com account to the educator role if you want to simulate a teacher user.


Troubleshooting: If the application fails to connect to the database or throws an error on startup, double-check the connection string configuration and that the SQL server is accessible. If you see an error related to ip, you may need to contact your DataBase server provider/Admin. Also ensure the target .NET framework is installed if you get a runtime error about frameworks. All necessary static files (CSS/JS) are in the wwwroot folder; if they don’t load, check that the paths in _Layout.cshtml are correct.


By following these steps, you should have a running instance of the STEMify Edu App. The architecture ensures that minimal configuration is needed beyond the database setup. Once running, you can explore the features through the web interface. The seeded admin account is useful for immediate access to admin features; just remember to secure it if this is a long-running deployment.
User Roles and Use Cases
The STEMify Edu App supports multiple user roles, each with different capabilities. The primary roles in the system are Admin, Editor, and User. Below we describe each role and some typical use cases (scenarios) involving them:
Administrator (Admin): This role has full control over the application. Admins can create and edit courses, quizzes, and questions. They can manage users and roles (for instance, assign a teacher the educator role, or create a new role if needed).
 Use Cases: An Admin logs in and navigates to the Admin Dashboard. From there:


Content Creation: Admin adds a new course (e.g., "php"), then creates a quiz under that course for the topic "Syntax & Basics". They input several questions of various types into the quiz. After creating, the quiz appears in the list of quizzes for students to take.


User Management: Admin reviews the list of registered users. They see a new teacher has signed up as a regular user. The Admin uses the Roles interface to assign this user the educator role, elevating their permissions to allow content editing. The Admin can also create a new user account (perhaps for a student who had trouble registering themselves) and set a temporary password for them.



Editor (Teachers): The editor role is intended for content curators like teachers or educators. An editor can create and modify quizzes and courses, similar to an Admin, but might not have access to system-wide settings or user management (depending on how the role is used in practice).
 Use Cases: A Teacher with editor rights logs in:


Quiz Administration: The teacher navigates to the Quizzes section and creates a new quiz for their class’s current topic (say, "Variables and Data Types"). They add questions to this quiz – a mix of multiple-choice and true/false questions that they intend to assign to students as homework.


Reviewing Content: The teacher notices a typo or an outdated question in an existing quiz. They use the Edit functionality to update the question text or correct answer. (For example, editing a True/False question’s statement).


User (Student): A User is the default role for anyone who registers through the app. Students use the platform to take quizzes and view learning materials. They have access to the list of courses and quizzes, can attempt quizzes, and see their own results. They cannot create or edit content.
 Use Cases: A Student logs in to the app:


Taking a Quiz: The student sees on their dashboard that there is a quiz available for "Syntax & Basics" (which the teacher or admin created). They click on it, read the instructions, and start the quiz. They answer a series of 10 questions. Upon submission, the app shows them their score (e.g., "8/10 correct") and maybe a breakdown of which answers were correct or incorrect. The result is saved so the student (and teachers) can review it later.


Browsing Courses: The student navigates to the Courses page to find learning material. They click on "Introduction to Java" and see a list of quizzes or modules under that course. They see what quizzes are under each course and choose what to do next.



User Interaction Flow: A typical flow bringing it all together: An admin adds content, a teacher assigns content, a student consumes content, and results are produced:
The Admin (or editor) creates a quiz and optionally associates it with a course and category.


The Student logs in, sees the quiz, and takes it. The system evaluates answers and creates a QuizResult entry.


The student is taken to a Results page for that quiz, and sees their score.

Role Permissions Summary: By design, the app enforces the following permissions:
Admins – can do everything (manage content, manage users, view all data).


educators – can manage content (courses/quizzes) and view results, but typically would not manage other users.


Users (Students) – can view and take quizzes, view their own results and available content. They cannot access admin-only pages (if they try, they should get an "Access Denied" page or be redirected).


Unauthenticated guests – can only see the public landing page or login/register. They cannot see any courses or quizzes or any other pages until they log in.


The separation of roles ensures the integrity of the content (students cannot modify or cheat by editing quizzes or add false information) and privacy of data (students can’t see others’ results unless permitted).

Testing and Validation Procedures
Throughout the development of the STEMify Edu App, various testing and validation steps were carried out to ensure the software meets its requirements and functions correctly. Below are the key testing approaches used:


Functional Testing of User Flows: Our team performed end-to-end tests of the main user scenarios:


Registration & Login: Verified that a new user can register (ensuring form validation catches errors like weak passwords or missing fields), then login with the set credentials. Also tested login with the seeded admin credentials to confirm the seeding works and the account is functional.


Role Restricted Access: Logged in as a normal user and attempted to access admin URLs (like /Course/Create or /Roles/Index) to ensure the app correctly restricts access. This should result in an "Access Denied" page or redirect to login. Conversely, verified that an admin can access these pages. This validates that [Authorize] attributes on controllers are properly set.


Creating Content: An admin went through the process of creating a course and a quiz with questions. After saving, navigated to the relevant listing pages to ensure the new entries appear. Edited some entries to check that updates are saved (e.g., changing a Course title or question text and seeing the change reflected on the list or detail page). Deleted an entry (a quiz) to ensure it’s removed from the list and database (and that no orphaned questions remain, which is handled by cascading deletes or explicit code in the controller).



Validation Testing: Many forms in the app have validation rules (some from data annotations, some via client-side scripts). For example, the Register form requires a valid email and a password that meets complexity rules. Similarly, the Add Question form requires certain fields depending on question type. These were tested by inputting invalid data:


Trying to register with an existing email (should show an error that the email is taken).


Submitting the Add Quiz form with an empty title (should not allow submission).


Leaving a multiple-choice question’s options empty to see if it either prevents save or handles it gracefully.


Entering an incorrect type of data (like letters in a field expecting a number) to ensure either the model or database will reject it. (For instance, the CategoryID in a Course should be a number from a dropdown; if someone manipulated the form and sent a non-number, the model binding and validation would catch it.)


UI Testing and Usability: The responsiveness of the UI was checked by resizing the browser or using device simulation. Ensured that the layout of the dashboard (course cards) wraps properly on smaller screens (the Bootstrap grid handles that automatically). The team also verified that navigation links are visible and functional on mobile . Also checked that forms and tables are not too large for mobile screens (columns stack or scroll as needed).


Security Testing: Basic security checks included:


Ensuring sensitive pages are protected (as mentioned in role testing).


Confirming that password fields are not exposed (the app uses HTML <input type="password"> so actual passwords don’t show on screen or in network calls).


Session management: logging out actually ends the session (tested by logging out and then trying to revisit a protected page to ensure it asks for login again).


The application runs under HTTPS in development (the template by default uses a developer certificate for localhost on HTTPS). This was checked by ensuring the callback URL during login was HTTPS. This is important for protecting credentials in transit.


Browser Compatibility: Tested the app on different browsers (Chrome, Firefox, Edge, maybe Safari) to ensure that the layout and functionality remain consistent. Thanks to Bootstrap and standards-based HTML, no major issues were expected. This test is primarily to ensure that, for example, some CSS or flexbox layout isn’t breaking in an older browser, or that the JavaScript (which is minimal) works everywhere.


In summary, while formal test cases and automated suites were limited, the application was manually tested in-depth by simulating real usage scenarios. This approach, combined with leveraging reliable frameworks, resulted in a reasonably stable application.
Future Enhancements
While the STEMify Edu App in its current state provides a solid foundation, there are numerous enhancements and extensions that can be pursued to add value to the project:
Enhanced Progress Analytics: Provide detailed dashboards for teachers, parents, and students. For teachers, implement a feature to view class performance at a glance – e.g., average scores per quiz, which questions most students struggled with, etc. For students, expand the profile stats into a progress report with graphs showing improvement over time, badges for accomplishments (like “5 Quizzes Passed!”), and recommendations for what to focus on next. For parents, possibly a weekly email report or a separate login to view their child’s progress in a read-only mode.


Parent/Guardian Accounts: Introduce a distinct Parent role with appropriate permissions. This would involve linking a parent account to one or more student accounts (perhaps via an invite or code). Parents would then have a tailored view where they can see only their own children’s performance and not all users. This role might have no content creation rights, just viewing rights. Implementing this would require adding a relationship between users (like a self-referential link or a separate mapping table for Parent-Student relationships) and updating the UI to handle parent views.


Gamification Elements: To increase student engagement, add gamification: points for each quiz taken, a leveling system, leaderboards, and badges for achievements. For example, a student earns 10 points for every quiz completed and extra points for high scores. They accumulate points to level up (which could unlock new avatar icons or just be for bragging rights). A leaderboard could show top performers in a class (if such grouping exists) or globally. Care would be needed to keep this positive and not demotivating for lower performers.


Lesson Content Integration: Currently, the app focuses on quizzes. An enhancement is to add course lessons or materials – essentially content pages or videos that teach a topic, which students can read/watch before taking the quiz. This would turn STEMify into more of a Learning Management System (LMS). Each course could have modules with lessons (text, images, embedded videos, etc.) followed by quizzes. This would require building a content educator (possibly a WYSIWYG editor for lesson text) and allowing file uploads for images or PDFs. It would greatly increase the educational value by combining instruction and assessment.


Expanded Question Types: Add more question formats: short answer (where a student types a sentence or number and it's matched against an answer key with some tolerance), matching (pair items from two lists), ordering (arrange steps in correct sequence), etc. Each new type would involve new UI components and model fields, but thanks to the current design (question type ID and separate tables), this can be integrated relatively smoothly. For automatic grading of short answers, consider simple keyword matching or even integrating an AI component for open-ended responses (though that’s complex).


Real-Time Features: Introduce real-time quiz competitions. For example, a teacher could start a quiz session and students join it (using SignalR for real-time web socket communication). Students answer each question timed, and the app shows a live leaderboard of the quiz competition. This simulates tools like Kahoot! and can make learning more interactive.


Mobile Application or PWA: Develop a dedicated mobile app (for iOS/Android) or at least convert the web app into a Progressive Web App (PWA) for better mobile experience. Young learners often have access to tablets or phones, so a native app or offline-capable web app could make usage more convenient. This could involve using Xamarin or .NET MAUI to build a cross-platform app reusing the existing backend via APIs, or enhancing the current web UI to be installable as a PWA and work offline for practice quizzes.


API for Integration: Expose a RESTful API for key functionalities (user authentication, retrieving quizzes, submitting answers, fetching results, fetching courses details and available resources). This would allow other clients (like the mobile app mentioned, or integration with other educational platforms. The use of .NET 8 allows the seamless integration of API’s. For instance, a school’s central system could pull quiz result data for report cards via an API. Implementing this would require adding controllers (or using Minimal APIs in .NET) that return JSON and appropriate authentication.


Improved UI/UX: While functional, the UI can always be improved. Future work could include a more polished visual design – custom CSS to replace default Bootstrap where needed (for a more unique look), adding animations or transitions for feedback (like a cool animation on quiz submission or when showing correct answers), and better navigation structure as content grows (maybe a sidebar for courses, search functionality to find quizzes by keyword, etc.). Additionally, accessibility should be considered: ensure proper ARIA labels, high-contrast mode for visually impaired students, and keyboard navigability.



AI-Powered Feedback: Another enhancement could be integrating AI to provide feedback on quiz answers. For example, if a student gets a question wrong, the system could give a brief explanation along with examples of the correct answer (the content for which could be written manually or potentially generated). AI could also adapt the difficulty of questions based on the student’s past performance (adaptive learning), or even generate new questions on the fly (though reliability of that would need careful oversight). This is an ambitious direction and would require external APIs and libraries.


Full Test Suite: From a process perspective, implement a comprehensive automated test suite. This includes unit tests for all critical functions (especially grading logic and flow for quizzes), integration tests for controller endpoints (ensuring that each page is loading and forms submit correctly), and perhaps UI tests to simulate a user clicking through the app. This will make the application more robust as new features are added.


References and External Dependencies
The development of STEMify Edu App made use of several external resources and libraries. Below is a list of references and dependencies that were instrumental in the project:
ASP.NET Core Official Documentation – Microsoft Docs for ASP.NET Core were referenced for setting up the project structure, configuring Identity, and implementing features like dependency injection and EF Core integration. (For example, tutorials on creating an MVC web app and adding Identity provided guidance on best practices.)


Entity Framework Core Documentation – The EF Core docs and examples were used, particularly for code-first migrations and relationships between entities. This ensured proper setup of the AppDbContext and how to configure one-to-many or one-to-one relationships for Quiz and Questions.


Bootstrap 5 Documentation – Used to design the responsive layout and components of the front-end. The classes for grid, cards, buttons, etc., are based on examples from getbootstrap.com. This dependency is included in the project via static files (under wwwroot/lib/bootstrap). License: Bootstrap is MIT licensed (no attribution required, but license files are included in the project).


jQuery & Plugins – jQuery library (license: MIT) and the jQuery Validation + Unobtrusive Validation plugins were used for client-side form validation. Their documentation (jquery.com, and Microsoft’s docs for unobtrusive validation) were references for enabling front-end validation. The script files are included in wwwroot/lib/jquery, wwwroot/lib/jquery-validation, etc., with their accompanying licenses.


Microsoft Identity Framework – The project relies on the ASP.NET Core Identity system. The structure for Identity (such as ApplicationDbContext, IdentityUser, etc.) is based on the template code provided by Microsoft when you create a new web app with “Individual User Accounts”. The default razor pages for Identity (like login, register, etc.) were scaffolded from the framework. Thus, the behavior of registration, login, and user/role management is largely inherited from this dependency.


Development & Build Tools:


Visual Studio 2022 – IDE used for coding and debugging.


.NET SDK and CLI – for building, running, and EF migrations.


Git – for version control.
Azure - for production DataBase and Hosting
.


Licenses and Credits:


The project includes LICENSE files for Bootstrap, jQuery, etc., in the repository as required. These acknowledge the use of those libraries.

Tools Used for Documention:


The project’s documentation foundation was compiled by ChatGPT’s “Deep Research” feature - based on our GitHub repository. 
Tools Used for Communication and Analysis:


Google Drive
Discord
WhatsApp


The STEMify Edu App is built on top of trusted frameworks and libraries. Our development team utilized these tools to implement standard features quickly and efficiently, allowing us to concentrate our custom work on the app’s unique elements—such as the quiz engine and educational tools. For common functionalities like UI layout, authentication, and data handling, we relied on well-established, open-source or Microsoft-provided solutions. This approach ensures the project remains free from restrictive licensing and aligned with industry best practices. Whenever we faced challenges, we turned to official documentation and community resources for guidance.

