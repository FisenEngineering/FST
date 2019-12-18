Fisen Sale Handoff Tool

Install FST on your machine (Steps may vary):
1. The install file is located in S:\Engineering\FST, double click on the exe file and let installer run. <br>
2. If and only if the install fails. <br>
    2a. Open the run command (Win+r). <br>
    2b. run "regedit", a word of caution: you break it you fix it. <br>
    2c. navigate to \HKEY_LOCAL_MACHINE\SOFTWARE\MICROSOFT\.NETFramework\Security\TrustManager\PromptingLevel <br>
    2d. Once there edit the "Data" values to "Enabled". <br>
    2e. Exit the Registry Editor.<br>
    2f. Try running the exe again.<br>
    
    
    
    
    
    
    
    
    
    
Source for install issue workaround: https://superuser.com/questions/1252575/unable-to-install-clickonce-application-due-to-security-settings-windows-10
    