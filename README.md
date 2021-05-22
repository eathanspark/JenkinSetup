# **Build Script Project for Building & Deploying .Net Solution Using Jenkins, MSBuild and Power Shell Script**

- [**Step 1:** Jenkins Server Installation and Testing on localhost:8080.] (https://github.com/eathanspark/JenkinSetup#step1-jenkins-server-installation-and-testing-on-localhost8080)
- [**Step 2:** Jenkins Plug-in installation.] (https://github.com/eathanspark/JenkinSetup#step-2-jenkins-msbuild--git-plugins-installation)
- **Step 3:** Create .Net Sample Project.
- **Step** **4:** Create MSBuild Script Project for build & deployment .
- **Step 5**: Create Jenkins Job to build and deploy .Net Sample Project using build script project.
- **Step 6:** Run Jenkins Job and Verify the deployment.
## **Step1: Jenkins Server Installation and Testing on localhost:8080**
### **Prerequisites:**
Minimum hardware requirements:

- 256 MB of RAM
- 1 GB of drive space 

Software requirements:

- Java
- Web browser
### **Download Jenkins**
Go to <https://www.jenkins.io/download/> and download stable windows installer
### **Installation steps** 
Go to download folder and double click on jenkins.msi and follow the steps below

![](https://github.com/eathanspark/JenkinSetup/blob/master/Blog/Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.001.png)

![](https://github.com/eathanspark/JenkinSetup/blob/master/Blog/Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.002.png) ![](Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.003.png)

![](https://github.com/eathanspark/JenkinSetup/blob/master/Blog/Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.004.png) 

![](https://github.com/eathanspark/JenkinSetup/blob/master/Blog/Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.005.png)

![](https://github.com/eathanspark/JenkinSetup/blob/master/Blog/Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.006.png) ![](Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.007.png) ![](https://github.com/eathanspark/JenkinSetup/blob/master/Blog/Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.008.png) ![](https://github.com/eathanspark/JenkinSetup/blob/master/Blog/Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.009.png)

Once installation is completed, Open web  browser and type http://localhost:8080/ in address bar, you will see screen like below.. then wait for a while it will ask for first time login password .

Go to the password file location as below copy password and click continue.

C:\Windows\system32\config\systemprofile\AppData\Local\Jenkins\.jenkins\secrets\initialAdminPassword

![](https://github.com/eathanspark/JenkinSetup/blob/master/Blog/Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.010.png)

![](https://github.com/eathanspark/JenkinSetup/blob/master/Blog/Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.011.png)

Skip Plugin Installation for now and create first admin user.

![](https://github.com/eathanspark/JenkinSetup/blob/master/Blog/Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.012.png)

![](https://github.com/eathanspark/JenkinSetup/blob/master/Blog/Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.013.png)

![](https://github.com/eathanspark/JenkinSetup/blob/master/Blog/Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.014.png)

![](https://github.com/eathanspark/JenkinSetup/blob/master/Blog/Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.015.png)

![](https://github.com/eathanspark/JenkinSetup/blob/master/Blog/Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.016.png)
## **Step 2: Jenkins MSBuild & Git Plugins installation**
Go to Dashboard click on Manage Jenkins then click on Manage Plugins it will redirect to plugins installation page like below

![](https://github.com/eathanspark/JenkinSetup/blob/master/Blog/Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.017.png)

Here you might find the error in red color even if you will navigate to the available tab there also you will find the same error, so to solve this issue you have two options 

 1) Install an SSL Certificate for connecting to Jenkins a secure service (SSL/TLS).

 2) Another quick way is to simply update site from https to http. Choose **Manage Jenkins->Plugin Manager->Advanced**

You will see the following update site default:

[**https://updates.jenkins-ci.org/update-center.json**](http://updates.jenkins-ci.org/update-center.json)

Now change it to 

[**http://updates.jenkins-ci.org/update-center.json**](http://updates.jenkins-ci.org/update-center.json)

You are done!

Now If you click on Available Tab you will found the different types of plugins available like below

![](https://github.com/eathanspark/JenkinSetup/blob/master/Blog/Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.018.png)
### **MSBuild & Git Plugins installation**
#### ***Set JDK Path***
Go to the Dashboard and click on Manage jenkins then Click on Global Tool Configuration 

In JDK section click Add JDK, Add jdk home path details whatever version install on your machine like below and click Save

![](https://github.com/eathanspark/JenkinSetup/blob/master/Blog/Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.019.png)

` `Search MSBuild & Git plugin, Check both checkbox and click on Install without restart

` `![](https://github.com/eathanspark/JenkinSetup/blob/master/Blog/Aspose.Words.96546ce1-2e58-4a21-b422-8af2c0b242b9.020.png)
