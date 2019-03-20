# Fun Factory .Net Core

## Overview

Fun Factory (FF) is an online computer parts retailer. FF sells computer parts on its own as component (e.g. a CPU) and as kits (e.g. Upgrade Kit). Kits contains two or more components. Sometimes, a kit may contain another kit or multiple kits as component e.g. PC kit may contain “upgrade kit” as one of its components. Sometimes a kit is made up multiple items (either components or kits) of multiple quantities. E.g. “upgrade kit” may contain 4 x 8gb RAM, 1 x CPU, 2 x Graphic cards.

FF is now building a new online store. You are one of the developers in the development team and assigned to do two work items and one task.

### Work Item #1
As a store owner, when a customer purchases the component(s) or the kit(s), the system must do the following.

- Component: the system must adjust the stock quantity of component and also adjust the stock quantities of the kits if the component is used in the kit.
- Kit: the system must adjust the stock quantity of the Kit as well as the stock quantities of the components which the kit is made up of.

Note: there is an extension method of the Component class, called AdjustStockQuantities.

### Work Item #2
As a store owner, on the component details page. When the customer clicks on the “Buy button” or press “enter key” after entering the quantity, instead of reloading the whole page, we want to refresh only the updated stock quantity and success message.

### Task #1
Do a code review of the project. Make a list of problems you have found and explain why are wrong.

### Things you need
1.	Visual Studio 2017 with local DB support (feel free to change to any DB tech)

### When you finish
1.	Zip and upload the finished solution to any online cloud storage
2.	Email the link to min.ko@k3btg.com and specify your name in the email

### Note
You must finish and submit the coding test at least one day before your face-to-face interview.

