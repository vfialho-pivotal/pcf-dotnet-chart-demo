# pcf-dotnet-chart-demo
### .Net Continuous Delivery Lab with Jenkins, MSBuild, and Artifactory

This lab is a basic introduction to .Net Continuous Delivery using Jenkins with MSBuild, Artifactory and Pivotal Cloud Foundry.

#### What you'll need for this lab:
```
1) Pivotal Cloud Foundry 1.6+

2) Windows 7+ to host Jenkins (and Artifactory)

3) Jenkins for Windows: 
- https://jenkins-ci.org/content/thank-you-downloading-windows-installer/

4) The following Jenkins Plugins:
- Artifactory
- MSBuild
- Git
- Parameterized Trigger
- Mask Passwords

This reference may be helpful: 
- http://justinramel.com/2013/01/15/5-minute-setup/

5) Artifactory:
- https://www.jfrog.com/open-source/

These references may be helpful:
- https://www.jfrog.com/video/artifactory-1-min-setup/
- https://www.youtube.com/watch?v=82sWH-5ooS8

6) Visual Studio Community 2013 Update 5:
- https://www.visualstudio.com/news/vs2013-update5-vs

7) Fork this repo:
- https://github.com/jjewett-pivotal/pcf-dotnet-chart-demo.git
```
#### Setup and Configuration
#### Artifactory
- localhost:8081
  * Default creds: admin/password
 
###### Create Local (Generic) Repository "cf-demo-repo" (Admin->Repositories->Local)

![](./screenshots/artifactory/Artifactory-Repo-1.png)
![](./screenshots/artifactory/Artifactory-Repo-2.png)
![](./screenshots/artifactory/Artifactory-Repo-3.png)

###### Create Permissions "cd-permissions" (Admin->Security->Permissions) and bind to repo "cf-demo-repo"

![](./screenshots/artifactory/Artifactory-Perms-1.png)
![](./screenshots/artifactory/Artifactory-Perms-2.png)
![](./screenshots/artifactory/Artifactory-Perms-3.png)
![](./screenshots/artifactory/Artifactory-Perms-4.png)
![](./screenshots/artifactory/Artifactory-Perms-5.png)

- Create User "jenkins" (Admin->Security->Users)

- Add User "jenkins" to Permissions "jenkins-cd" (Admin->Security->Permissions->Users) 
  * Select Deploy, Annotate, and Read

#### Jenkins
- localhost:8080







