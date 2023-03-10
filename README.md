# Premium Calculator

- Working demo at: https://premium-calculator.azurewebsites.net/
- API swagger docs at: https://premium-calculator-api.azurewebsites.net/swagger/

Some assumptions made;

- Since the user is entering their personal details, I have assumed that this is a public facing page (and the user would not be authenticated) so there are no security restrictions on any of the endpoints.
- Even though there is a requirement for an Age and Date of Birth field, I only added a Date of Birth field and the Age is calculated automatically.
- For the maximum age, I have assumed this may be a value that an admin may need to change in the future so I have added it to the db instead of a config file.
- In case the rating factors are sensitive, these values are never sent to the client side. 
