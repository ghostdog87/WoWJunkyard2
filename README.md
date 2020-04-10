# WoWJunkyard2
Course project for Softuni - ASP.NET Core and Vue JS 2020

## WoW Information Site

## Description

This is a web page that gives information about characters in World of Warcraft and news related to the game.
It provides the following  information: news, characters, character items, character progress in mythic dungeons,
detailed information about characters. 
Search bar to find characters.
Shows the details for each character item.


## Tools and Libraries used in the project:
  ### Back-end
	- MSSQL server
	- Mediator by Jimmy Bogard to implement CQRS (Mediator pattern)
	- FluentValidation library to control client-side validations (similar to DataAnnotations attributes).
  - MongoDB to collect Blizzard API calls

  ### Client-side
  - Vue
  - Vuetify and Bootstrap
  - Vuex
  - Vue router
  - Jquery and other minor libraries based on Jquery
  - WoWhead plugin to display tooltips

## Profiles

### Admin:
	email: TBA
	password: TBA

### Users:
	email: gosho@abv.bg
	password: Ghostd0g_87

  email: pesho@abv.bg
	password: Ghostd0g_87

  email: sasho@abv.bg
	password: Ghostd0g_87

## Entities

### WoWUser (Inherites IdentityUser)
  - DisplayName (string)
  - Posts (List of Posts)

### Posts
  - Id (Integer)
  - Title (string)
  - Description (string)
  - PostedOn (datetime)
  - Image (string)
  - User (WoWUser)

### Character
  - Id (Integer)
  - Level (Integer)
  - Items (List of Items)
  - Price (Decimal)
  - Dungeons (List of accomplished mythic dungeons)
  
### Item
  - Id (Integer)
  - Name (string)
  - ItemType (Enum head,chest,shoulders etc.) 
  
### Dungeon
  - Id (Integer)
  - Name (string)
  - AccomplishedLevel (integer - best accomplished level)


