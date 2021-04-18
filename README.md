# Sorting API

A sorting API was created using a .NET framework and C# language The essence of it, is that a user can utilize an endpoint (in total there 2)
to give a set of integer values to it as a load and the code on the back-end will process user's data and sort the given values.

## Concept

For simplicity, we will assume the user is running this code on their machine and currently testing the API functionality through the root of it being localhost.

Essentially, the idea is that the user, can navigate to the endpoint `localhost:5001/Sorting/{values}` and in a single line which can be treated as a string, insert a set of numerical value that will be arranged in an ascending order, by multiple algorithms. The user will be able to see with the API's response how long each algorithm has taken to sort the data, evaluated in milliseconds.

The caveat here is that only integer values can be processed (and only integer values of int32 format, including the negative values). This is made to deliver a working sorter, rather than an ultimate sorter that can work with any type of data. Though on the bright side - the user does not have to worry about various rules that go with the API, as most of the checks to prevent incorrect inputs have been implemented. In other words, if the user passes an input such as `1 2 3 check Test23 42,42.42 $%as3as 21474836470000` the sorting algorithm will find incorrect inputs and as a final result will return the following answer: `1 2 3 42`. As you can see, any text values or values that are too large to be fit in the int32 memory, or values that have commas (in this case anything before the comma or a dot is taken as an int value), indicating that they might be treated as floats or doubles - actually get rejected for processing and only those were retained that actually fit in the scope of rules under which the API functions. The only real rule that the user has to abide by - use spaces as separators between any values. This is the parsing methodology applied to the way the information is read by the code.

A second endpoint simply shows to the user what was the last input they have entered, and how it got sorted. The endpoint is simply at `localhost:5001/Sorting/`.

Further you can see two screenshots of the endpoints being utilized and the outputs the API produces.

![](https://github.com/Si-ja/SortingAPI/blob/main/VisualsDemo/SortingInputValues.png "Sorting API")

![](https://github.com/Si-ja/SortingAPI/blob/main/VisualsDemo/SortingInputLogs.png "Sorting Logs")

## Sorting Algorithms

The sorting algorithms implemented can be added or removed depending on the need. In essence, the code was arranged in such way, that you can have as many of them as required, as long as you just stick to the rule, that they process data types of `int[]` format and they are primarily controlled by the actions of DataManipulator class and SortingController class. The first has rules when they are used, while the later just calls them depending on what particular sorter do we want to see implemented.

## Notices

* The DataManipulator class might not necessarily go into the Controllers section, but this happened due to a bit different planning in the implementation strategy. If code refactoring would have been done, most likely to avoid much hassle, but make the code a bit easier to maintain - it would be more appropriate to put the said class in one of the folders in the Scripts section. 
* The created API also has a swagger interface, which means that you can test and play around with API endpoints, without really being concerned how to enter the data into a browser window or through a `curl` command. They look something as follows:

![](https://github.com/Si-ja/SortingAPI/blob/main/VisualsDemo/Swagger.png "Swagger")

![](https://github.com/Si-ja/SortingAPI/blob/main/VisualsDemo/SwaggerLogs.png "Swagger Logs")

![](https://github.com/Si-ja/SortingAPI/blob/main/VisualsDemo/SwaggerSorting.png "Swagger Logs")
