# TechnicalAssessment
## Configuration:
### If you want to run the application, you must configure the connection string in **web.config** file.
## Login credentials:
1. Admin User:
   - UserName = "AdminOne",        
   - Password = "Test@1234", 

2. Doctor:
   - UserName = "DoctorOne",
   - Password = "Test@1234",

3. Patient:
   - UserName = "PatientOne"
   - Password = "Test@1234",

### Web.config
```xml
<connectionStrings>
		<add name="DefaultConnection" providerName="System.Data.SqlClient" connectionString="" />
</connectionStrings>
```
