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
  
Source for install issue workaround: https://superuser.com/questions/1252575/unable-to-install-clickonce-application-due-to-security-settings-windows-10<br>



Install the .pfx key to your machine.<br>
1. Open "C:\Users\{YOURUSERNAME}\source\repos\fisen-sale-handoff-tool\Fisen Sales Handoff Tool\Fisen Sales Handoff Tool_2_TemporaryKey.pfx"<br>
2. Right click and select "Install PFX"<br>
3. Select "Local Machine"<br>
4. File Import just click next<br>
5. Password: fisen123<br>
6. Certificate Store just click next<br>
7. Click Finish<br>

Installing PFX Key to Strong Name CSP<br>
1. Try building and running FST<br>
2. If it does error out you need to add the PFX to the Strong Name CSP<br>
3. Open the "Developer Command Prompt for VS 2019" Under the Visual Studios folder under the start command<br>
4. On the CMD run "sn -i mykey.pfx VS_KEY_XXXXXXXXXXXXXXXX"<br>
    4a. The key is found in your C:\Users\{YOURUSERNAME}\source\repos\fisen-sale-handoff-tool\Fisen Sales Handoff Tool<br>
    4b. The VS key number is found in the build error notes in VS. Not sure how else to find it. <br>
5. Once prompted enter the password: fisen123<br>


Source: https://social.msdn.microsoft.com/Forums/aspnet/en-US/cc7a38fc-dde0-4280-815c-cdd6ddbd992d/the-key-file-may-be-password-protected-to-correct-this-try-to-import-the-certificate-again-or?forum=tfsbuild<br>
