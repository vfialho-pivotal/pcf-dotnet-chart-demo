# pcf-dotnet-chart-demo
### .Net Continuous Delivery Lab with Jenkins, MSBuild, and Artifactory

This lab is a basic introduction to .Net Continuous Delivery using Jenkins with MSBuild, Artifactory and Pivotal Cloud Foundry 1.6+.

#### What you'll need for this lab:

1) Windows 7+

2) Jenkins for Windows: 
https://jenkins-ci.org/content/thank-you-downloading-windows-installer/

3) The following Jenkins Plugins:
- Artifactory
- MSBuild
- Git
- Parameterized Trigger

This reference may be helpful: 
http://justinramel.com/2013/01/15/5-minute-setup/

4) Artifactory:
https://www.jfrog.com/open-source/

This reference may be helpful:
https://www.jfrog.com/video/artifactory-1-min-setup/

5) Visual Studio Community 2013 Update 5:
https://www.visualstudio.com/news/vs2013-update5-vs

6) This repo:
https://github.com/jjewett-pivotal/pcf-dotnet-chart-demo.git

#### Setup and Configuration
#### Jenkins
#### Artifactory
- localhost:8081
  * Default creds: admin/password
- Create Local (Generic) Repository "pivotal" (Admin->Repositories)
- Create User "jenkins" (Admin->Security->Users)
- Create Permissions "jenkins-cd" (Admin->Security->Permissions)
- Add User "jenkins" to Permissions "jenkins-ci" (Admin->Security->Permissions->Users) 
  * Select Deploy, Annotate, and Read






