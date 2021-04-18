# Sorting API

A sorting API was created using a .NET framework and C# language. The essence of it, is that a user can utilize an endpoint (in total there 2) to give a set of integer valus to it as a load and the code on the back-end will process user's data and sort the given values.

## Concept

For simplicity, we will assume the user is running this code on their machine and currently testing the api functionality through the root of it being localhost.

Essentially, the idea is that the user, can naviage to the endpoint `localhost:5001/Sorting/{values}` and in a single line which can be treated as a string, insert a set of numerical value that will be arranged in a ascending order, by multiple algorithms. The user will be able to see with the API's response - how long each algorithm has taken to sort the data.

The caveate here is that only integer values can be processed (and only integer values of int32 format, incluiding the negative values). This is made to deliver a working sorter, rather than an ultimate sorter that can work with any type of data. Though on the bright side - the user does not have to worry about various rules that go with the API, as most of the checks to prevent incorrect inputs have been implemented. In other words, if the user even passes an input such as `1 2 3 check Test23 42,42.42 $%as3as 21474836470000` the sorting algorithm will find incorrect inputs and as the final result will return the following answer: `1 2 3 42`. As you can see, any text values or values that are too large to be fit in the processing memory, or values that have commas, indicating that they might be treated as floats or doubles - actually got rejected for processing and only those were retained that actually fit in the scope of rules under which the API functions. The only real rule that the user has to abide by - use spaces as seperators between any values. This is the parsing methodology applied to the way the information is read by the code.

A second endpoint simply would show to the user what was the last input they have entered, and how it got sorted. The endpoint is simply at `localhost:5001/Sorting/`.

Further you can see two screenshot of the endpoints being utilized and the outputs the API produces.

![](https://github.com/Si-ja/SortingAPI/blob/main/VisualsDemo/SortingInputValues.png "Sorting API")

![](https://github.com/Si-ja/SortingAPI/blob/main/VisualsDemo/SortingInputLogs.png "Sorting Logs")

## Sorting Algorithms

The sorting algorithms implemented can be added or removed depending on the needs. In essence, the code was arranged in such way, that you can have as many of them as required, as long as you just stick to the rule, that they process data types of `int[]` format and they are primarily controlled by the actions of DataManipulator class and SortingController class. The first has rules when they are used, while the later just calls them depending on whether we want to see a particular sorter being used or not.

## Notices

* The DataManipulator class might not necesserily go into the Controllers section, but this happened due to a bit different planning in the implementation strategy. If code refactoring would have been done, most likely to avoid much hassel, but make the code a bit easier to maintain - it would be more appropriate to put the said class in one of the folders in the Scripts section. 
* The created API also has a swagger interface, which means that you can test and play around with API endpoints, without really being concerned how to enter the data into a browser window or through a `curl` command. The look something as follows:

![](https://github.com/Si-ja/SortingAPI/blob/main/VisualsDemo/Swagger.png "Swagger")

![](https://github.com/Si-ja/SortingAPI/blob/main/VisualsDemo/SwaggerLogs.png "Swagger Logs")

![](https://github.com/Si-ja/SortingAPI/blob/main/VisualsDemo/SwaggerSorting.png "Swagger Logs")
