# Requirements for Badgemania

## Product Description

The product is a web application that helps students, from elementary to high school, to increase their motivation in school.
To increase their motivation, they will be given digital badges for the tasks that they complete.
The teacher specifices the tasks in the applikation and decides when a task is completed.
So the applikation is bringing gamification to the classroom and the learning process.

## Functional Requirements (in this task now)

- if no user is logged in
  -  Start page (Home page) with a presentation of the product.
  -  Solutions page with info about different solutions for different type of users like students, teachers and school admin.
  -  Pricing page with info about different packages that has different amount of teachers and student accounts.
  -  About page with info about Badgemania and what it does.
  -  Contact us page with information about how to get in touch with us.
  -  Login page where different users can sign in.
- if teacher is logged in
  -  Badgegroups page where user can se their badgegroups only and a "Create Badgegroup" button.
  -  CreateBadgegroups page where user can create a new badgegroup by filling a form with just a name of the badgegroup or go back to Badgegroups.
  -  BadgegroupId page where user can switch between this page and 3 other (Students, Badgetypes and Badges pages).
  -  Students page will show the students in this badgegroup now.
  -  Badgetypes page has a p-tag that just tells whats comming later here now.
  -  Badges page has a p-tag that just tells whats comming later here now.
  -  Schools page has a p-tag that just tells whats comming later here.
- if student is logged in
  -  Badgegroups page where user can se their badgegroups only
  -  BadgegroupId page where user later will be able to se it's badges
- if super admin is logged in
  -  Schools page were now is only a p-tag with text

## Functional Requirements (later in the future to add)

- if teacher is the logged in user
    - BadgegroupId page will show a dashboard of students total earned badges
      - Students
        - Add student to Badgegroup
        - Delete student from Badgegroup
      - Badgetypes
        - Add Badgetype to Badgegroup
        - List of Badgetypes
        - Delete Badgetype from Badgegroup
        - Update Badgetype in Bagegroup 
      - Badges
        - Add Badge to Badgegroup
        - List of Badges
        - Delete Badge from Badgegroup
        - Update Badge in Bagegroup
- if student is the logged in user
  - Badgegroups page with all groups the student belongs to
  - BadgegroupId page will show a dashboard of all user badges earned and that can be earned
- if school admin is the logged in user
  - Student page with list of students in the school
    - Create a student
    - Remove a student
    - Update a student
  - Teacher page with list of teachers in the school
    - Create a teacher
    - Remove a teacher
    - Update a teacher
- if super admin is the logged in user
  - School page with list of schools in the application
    - Create a school
    - Remove a school
    - Update a school
