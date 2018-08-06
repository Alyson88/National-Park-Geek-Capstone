# **National Park Geek Capstone Project**
<br><br>
# **Requirements:** 
1. **Home Page**
    * View an alphabetical list of all parks
        * Show: Picture, Name, Description
    * Select a park and go to Park Detail Page
<br/><br/>
1. **Detail Page**
    * Show ALL data about the selected park
    * 5-Day Expected Weather Forecast
        * Show: Image & High/Low temperatures with F or C 
        * For Today, include a "recommendation" based on the forecast 
            * Snow: Pack snowshoes
            * Rain: Pack rain gear and wear waterproof shoes
            * Thunderstorms: Seek shelter and avoid hiking on exposed ridges
            * Sunny: Pack sunblock
        * For Today, include a "recommendation" based on temperature
            * Temp > 75: Bring an extra gallon of water
            * ABS Temp range > 20: Wear breathable layers
            * Temp < 20: Beware of the dangers of exposure to frigid temperatures
        * Select Fahrenheit or Celsius
            * Must be remembered in **SESSION**
<br/><br/>
1. **Survey Page**
    * To *vote* on a park
        * Select favorite park from a drop-down-menu of all park names
        * Enter email address & residence state
        * Select activity level from a drop-down-menu
            * Choices: Inactive, Sedentary, Active, Extremely Active
        * ALL fields are **REQUIRED** and must be **VALIDATED**
        * Click Submit and be directed to the Favorite Parks Page
<br/><br/>
1. **Favorite Parks Page**
    * List parks in descending order of the number of *votes* they have
    * Ties in alphabetical order
    * Show: Name & count
    * Do not include parks with 0 *votes*
<br/><br/>
# **Park Codes:**
**CVNP** - Cuyahoga Valley National Park <br>
**ENP** - Everglades National Park <br>
**GNP** - Glacier National Park <br>
**GCNP** - Grand Canyon National Park <br>
**GTNP** - Grand Teton National Park <br>
**GSMNP** - Great Smoky Mountains National Park <br>
**MRNP** - Mount Rainier National Park <br>
**RMNP** - Rocky Mountain National Park <br>
**YNP** - Yellowstone National Park <br>
**YNP2** - Yosemite National Park
<br/><br/>

# **Models:**
### 1. **ParkForList:**
* **ParkCode** - varchar(10) - string
* **ParkName** - varchar(200) - string
* **ParkDescription** - varchar(max) - string
<br/><br/>
### 2. **ParkDetails:**
* **ParkCode** - varchar(10) - string
* **ParkName** - varchar(200) - string
* **ParkState** - varchar(30) - string
* **Acreage** - int
* **ElevationInFeet** - int
* **MilesOfTrail** - real - double
* **NumberOfCampsites** - int
* **Climate** - varchar(100) - string
* **YearFounded** - int
* **AnnualVisitorCount** - int
* **InspirationalQuote** - varchar(max) - string
* **InspirationalQuoteSource** - varchar(200) - string
* **ParkDescription** - varchar(max) - string
* **EntryFeeInDollars** - int (with $) - decimal (with $)
* **NumberOfAnimalSpecies** - int 
* **FiveDayForecast** - Weather
    * fiveDayForecastValue - int
    * lowTempInFahrenheit - int
    * lowTempInCelsius - int
    * highTempInFahrenheit - int
    * highTempInCelsius - int
    * forecast - varchar(100) - string
* **SurveyCount** - int
<br/><br/>
### 3. **Weather:**
* **ParkCode** - varchar(10) - string
* **FiveDayForecastValue** - int
    * 1 = Today
    * 2 = Tomorrow
    * 3 = The Next Day
    * 4 = The Day after That
    * 5 = The Next Day after That
* **LowTempInFahrenheit** - int
* **LowTempInCelsius** - int 
* **HighTempInFahrenheit** - int
* **HighTempInCelsius** - int 
* **Forecast** - varchar(100) - string.ToLower()
<br/><br/>
### 4. **Survey:**
All fields are **required** and need **validation**
* **FavoritePark** - varchar(10) - string (use parkCode, but show parkName)
* **EmailAddress** - varchar(100) - string
* **ResidenceState** - varchar(30) - string
* **ActivityLevel** - varchar(100) - string
<br/><br/>
### 5. **Favorite Parks:**
* **ParkCode** - varchar(10) - string
* **ParkName** - varchar(200) - string
* **SurveyCount** - int
<br/><br/>
# **DAO Interfaces & DAOs:**
### 1. IParkDAO
* GetAllParks List
* GetParkDetail Park
* GetAllParkCodesAndNames List
* GetFavoriteParks List
### 2. ISurveyDAO
* AddSurvey bool
### 3. ParkDAO
* GetAllParks List
* GetParkDetail Park
* GetAllParkCodesAndNames List
* GetFavoriteParks List
### 4. SurveyDAO
* AddSurvey bool
<br/><br/>
# **Controllers:**
### 1. HomeController
## **Controller Actions:**
* Home [HtmlGet]
* ParkDetail [HtmlGet]
* Survey [HtmlGet]
* Survey [HtmlPost]
* FavoriteParks [HtmlGet]
<br/><br/>
# **Views:**
### 1. Home
* Index
* Detail
* Survey
* FavoriteParks
<br/><br/>
# **Steps:**
1. Add DAL folder
1. Add Content folder
1. Add img folder to Content folder
1. Add images to img folder
1. Add Models.cs files
1. Add DAO Interfaces.cs files
1. Add DAO.cs files
1. Create kernel binding in NinjectWebCommon file
1. Add connectionString to Web.config
1. Add Model details
1. Add controller constructor
1. Add Controller Actions
1. Add Views
1. Add .css file for each View
1. Make sure there are _Layout.cshtml and _ViewStart.cshtml files
1. Add DAO Interfaces details
1. Add DAO details
1. Add Controller Action details
<br/><br/>
Alyson Wood