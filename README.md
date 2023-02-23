# Premium Calculator

Working demo at: https://premium-calculator.azurewebsites.net/
API swagger docs at: https://premium-calculator-api.azurewebsites.net/swagger/

Some assumptions made;

- Since the user is entering their personal details, I have assumed that this is a public facing page and the user would not be authenticated. So, there is no security restrictions added to eny of the endpoints.
- Even though there is a requirement for an Age and Date of Birth field, I only added a Date of Birth field and the age is calculated automatically.
- For the maximum age, I have assumed this may be a value that an admin may need to change so I have added it to the db instead of a config file.
