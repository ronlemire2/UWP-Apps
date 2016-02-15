# UWP-Apps

**FeedReader**

1. Comics (about 300 feeds, uses SemanticZoom)
2. Politics (includes Political Cartoons)
3. Tech 

**NFLWatcher**

A UWP Prism Client written in C# XAML that is based on the MVVM pattern. Its purpose is to display NFL Schedule and GameScore data. It does not do any updating of this data. NFLService uses HttpClient to get NFL data from a public feed. Currently it displays the Weekly Schedules of NFL games by Year, SeasonType, and Week in a ListView. Select a Game in the ListView and you will be taken to Game's BoxScore. On the BoxScore Page press the Hightlights button to get game videos from YouTube. Future enhancements include PlayByPlay and PlayerStats. Go to ronlemire/ScreenshotViewer to see some sample schedule and box score data.

In order to run NFLWatcher Highlights you must enter your YouTube API key into the SearchYouTube method of the MyYouTubeService class. To get a free YouTube API Key go to: https://developers.google.com/youtube/v3/getting-started. There is a usage limit on the free account. The Hightlights Page is also a YouTube search page. Enter any text in the Search textbox and press the Search button to get YouTube videos on that search item.

**PrismBasicsDemo**

1. MVVM
2. Dependency Injection
3. Commanding
4. Navigation
5. Lifecycle
6. Validation
7. Event Aggregator
8. Testing

Screenshots at https://github.com/ronlemire2/UWP-ScreenshotViewer.

**Syncfusion Community Edition**

Syncfusion offers its complete Essential Studio free to developers under a Community License. It includes all products: UWP, Web, Mobile and Desktop. Go to www.syncfusion.com and click on 'COMMUNITY LICENSE'.

**SfDataGridDemo for Line of Business Applications**

All the SfDataGridDemo examples come from Syncfusion's SampleBrowser_2015 Grid folder. I've made each SampleBrowser example a Page in a PrismShellTemplate app. I changed them to fit into Prism for UWP and to add functionality. It was a good learning experience to see Syncfusion code. SfDataGrid has many capabilties that can be leveraged in LOB Apps including:

1. Editing
2. Sorting
3. Excel type Filtering
4. DragAndDrop Multi-Level Grouping
5. Group Summaries
6. much more...


**SfChartDemo for Line of Business Applications**

1. Stacked Charts
2. Pie Charts
3. Annotations
4. Auto Scrolling
5. 3D Charts (future)

**YouTubePlayer**

1. Enter search text
2. Press search button
3. Select a search result form comboBox
4. Screenshots at: ronlemire2/Testers/YouTubePlayer/YouTubePlayer/Screenshots 

A UWP Client written in C# XAML that is based on the MVVM pattern. In order to run the YouTubePlayer you must enter your YouTube API key into the SearchYouTube method of the MyYouTubeService class.      To get a free YouTube API Key go to: https://developers.google.com/youtube/v3/getting-started. There is a usage limit on the free account.

**AdventureWorks (work in progress)**

1. HumanResources
2. Production (future)
3. Purchasing (future)
4. Sales (future)


**BingSearcher (work in progress)**

1. Images
2. Videos (future)
3. News (future)
4. Maps (future)


# Prism UWP-ProjectTemplates
Visual Studio 2015 Project Templates for Universal Windows Platform (UWP)

**PrismShellTemplate and PrismSimpleTemplate are an evolution of 2 other UWP Project Templates: UWPShellTemplate and UWPSimpleTemplate which can be found with their notes in ronlemire2/UWP-Testers.

**PrismShellTemplate**

For some unknown reason even though the PrismShellTemplate builds successfully, there are some code squiggles and the Prism.Unity reference is missing. If that is the case, close Visual Studio then restart it and rebuild the solution.

**Steps to make any of solutions a Visual Studio Project Template:**

1. Open solution in Visual Studio
2. Go to Main Menu->File menu
2. Select Export Template
3. Choose Template Type (select Project Template)
4. Select Template Options (enter a Description)
5. Press Finish button
6. Project Template appears in Visual Studio under Installed -> Templates -> Visual C# Visual Studio creates a .zip file in:
	* ..\Users\(user)\Documents\Visual Studio 2015\Templates\ProjectTemplates
	* ..\Users\(user)\Documents\Visual Studio 2015\MyExportedTemplates
	* ..\Users\(user)\AppData\Roaming\Microsoft\VisualStudio\14.0\ProjectTemplatesCache (after it has been used)
7. To remove the Project Template just delete the .zip files from the above 3 locations.

FixUps:

When the Visual C# Project Template is used to create a New Project all the namespaces are converted to the New Project name but the Packages.appxmanifest still contains template names so replace the word UWPShellTemplate with <New Project Name> in these places:
1. Application tab
	* Display name
	* Entry point - keep the .App
	* Description
2. Packaging tab
	* Package display name
	* Delete the Package name GUID and replace with a new one from Tools->Create GUID->#4 Registry removing the brackets
3. If not using ARM device, switch Solution Platform to x86 or x64 
 
# UWP-ScreenshotViewer
**Description**

ScreenshotViewer is a UWP Single Page App whose purpose is to centralized all my UWP App screenshots. The screenshots are displayed in a CoverFlow control. They are also listed in a ListView on the left of the CoverFlow. The ListView is binded to a CollectionViewSource for grouping purposes and is part of a SemanticZoom control. The ListView items in the ZoomedIn view are synchronized with the CoverFlow.

**Setup**

Screenshots are located at ronlemire2/UWP-ScreenshotViewer. **ScreenshotViewer does not work from this folder.** It works from the Local Data folder which allows adding more screenshots without rebuilding the app. To view the screenshots with the ScreenshotViewer, copy the contents of the UWP-ScreenshotViewer folder (including all .png files and the .json file) and place them in the App's Local Data folder (e.g. C:\Users\Ron\AppData\Local\Packages\EA5A52BD-749F-4151-9C37-6D5BC4D269FF_y2prydnfg9dzy\LocalState). Get the package part of this path from the Package.appmanifest's Packaging tab. **Note that the Local Data folder does not exist until ScreenshotViewer has been deployed.**


**Use**

The ListView starts in ZoomedIn view. Group Headers have a black background, white border and large font. Group Items have no border and a smaller font. Click a Group Header to zoom out. This will display only the groups in a list. Click a group item to go back to the ZoomedIn view positioned at that group. Click a Group Item to see it in the CoverFlow. ListView works with keyboard (up/down keys) and mousewheel. 
Below the CoverFlow are details about the Selected Screenshot. Below the details is a slider to move through the CoverFlow. Slider works with keyboard (left/right keys). Clicking a non-selected Screenshot in the CoverFlow will make it the Selected Screenshot. Mousewheel over the CoverFlow will move through screenshots. To add additional screenshots, add screenshot to Local Data folder and update screenshots.json.

