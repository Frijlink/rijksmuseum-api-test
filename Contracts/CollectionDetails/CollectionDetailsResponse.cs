using System.Text.Json.Serialization;

namespace RijksmuseumApiTest.Contracts.CollectionDetails;

public class CollectionDetailsResponse
{
    [JsonPropertyName("elapsedMilliseconds")]
    public required int ElapsedMilliseconds { get; set; }

    [JsonPropertyName("artObject")]
    public required ArtObject ArtObject { get; set; }

    [JsonPropertyName("artObjectPage")]
    public required ArtObjectPage ArtObjectPage { get; set; }
}

/*
{
  "elapsedMilliseconds": 207,
  "artObject": {
    "links": {
      "search": "http://www.rijksmuseum.nl/api/nl/collection"
    },
    "id": "nl-SK-A-1328",
    "priref": "6239",
    "objectNumber": "SK-A-1328",
    "language": "nl",
    "title": "De Gele Rijders",
    "copyrightHolder": null,
    "webImage": {
      "guid": "5c1034d9-7c84-4fc7-acdb-81828508a0b7",
      "offsetPercentageX": 50,
      "offsetPercentageY": 6,
      "width": 4867,
      "height": 7171,
      "url": "https://lh3.googleusercontent.com/eyfjWtgsGz7l48QFu3gZ6WN2IV1hfh8EFpu6Fs-BztYLd9efOoyGpLvP9ier3VZmn7Med3PO-ajadOQ7nT8tb1FJxWJm=s0"
    },
    "colors": [
      {
        "percentage": 6,
        "hex": "#CDC096"
      },
      {
        "percentage": 19,
        "hex": " #998865"
      },
      {
        "percentage": 8,
        "hex": " #AE9F7D"
      },
      {
        "percentage": 12,
        "hex": " #5B4C36"
      },
      {
        "percentage": 22,
        "hex": " #2D2721"
      },
      {
        "percentage": 30,
        "hex": " #827148"
      }
    ],
    "colorsWithNormalization": [
      {
        "originalHex": "#CDC096",
        "normalizedHex": "#E0CC91"
      },
      {
        "originalHex": " #998865",
        "normalizedHex": "#E0CC91"
      },
      {
        "originalHex": " #AE9F7D",
        "normalizedHex": "#E0CC91"
      },
      {
        "originalHex": " #5B4C36",
        "normalizedHex": "#737C84"
      },
      {
        "originalHex": " #2D2721",
        "normalizedHex": "#000000"
      },
      {
        "originalHex": " #827148",
        "normalizedHex": "#E0CC91"
      }
    ],
    "normalizedColors": [
      {
        "percentage": 33,
        "hex": "#D2B48C"
      },
      {
        "percentage": 30,
        "hex": " #808000"
      },
      {
        "percentage": 22,
        "hex": " #000000"
      },
      {
        "percentage": 12,
        "hex": " #696969"
      }
    ],
    "normalized32Colors": [
      {
        "percentage": 64,
        "hex": "#E0CC91"
      },
      {
        "percentage": 22,
        "hex": " #000000"
      },
      {
        "percentage": 12,
        "hex": " #737C84"
      }
    ],
    "materialsThesaurus": [],
    "techniquesThesaurus": [],
    "productionPlacesThesaurus": [],
    "titles": [
      "De Gele Rijders",
      "Rijdende artillerie"
    ],
    "description": "Rijdende artillerie. Een groep ruiters komt een duin afgestormd. Dit werk is ook bekend onder de titel 'De Gele Rijders'.",
    "labelText": null,
    "objectTypes": [
      "schilderij"
    ],
    "objectCollection": [
      "schilderijen"
    ],
    "makers": [],
    "principalMakers": [
      {
        "name": "George Hendrik Breitner",
        "unFixedName": "Breitner, George Hendrik",
        "placeOfBirth": "Rotterdam",
        "dateOfBirth": "1857-09-12",
        "dateOfBirthPrecision": null,
        "dateOfDeath": "1923-06-05",
        "dateOfDeathPrecision": null,
        "placeOfDeath": "Amsterdam",
        "occupation": [
          "prentmaker",
          "tekenaar",
          "schilder",
          "fotograaf"
        ],
        "roles": [
          "schilder"
        ],
        "nationality": "Nederlands",
        "biography": null,
        "productionPlaces": [],
        "qualification": null,
        "labelDesc": "George Hendrik Breitner (12-sep-1857 - 05-jun-1923)"
      }
    ],
    "plaqueDescriptionDutch": null,
    "plaqueDescriptionEnglish": null,
    "principalMaker": "George Hendrik Breitner",
    "artistRole": null,
    "associations": [],
    "acquisition": {
      "method": "aankoop",
      "date": "1886-10-01T00:00:00",
      "creditLine": null
    },
    "exhibitions": [],
    "materials": [
      "doek",
      "olieverf"
    ],
    "techniques": [],
    "productionPlaces": [],
    "dating": {
      "presentingDate": "1885 - 1886",
      "sortingDate": 1885,
      "period": 19,
      "yearEarly": 1885,
      "yearLate": 1886
    },
    "classification": {
      "iconClassIdentifier": [
        "45B",
        "46C131"
      ],
      "iconClassDescription": [
        "de soldaat; het leven van een soldaat",
        "riding a horse, ass, or mule; rider, horseman"
      ],
      "motifs": [],
      "events": [],
      "periods": [],
      "places": [],
      "people": [],
      "objectNumbers": [
        "SK-A-1328"
      ]
    },
    "hasImage": true,
    "historicalPersons": [],
    "inscriptions": [],
    "documentation": [
      "Anoniem [A.C. Loffelt?], Het Vaderland : staat- en letterkundig nieuwsblad (1886) 10-11 okt."
    ],
    "catRefRPK": [],
    "principalOrFirstMaker": "George Hendrik Breitner",
    "dimensions": [
      {
        "unit": "cm",
        "type": "hoogte",
        "precision": null,
        "part": "doekmaat",
        "value": "115"
      },
      {
        "unit": "cm",
        "type": "breedte",
        "precision": null,
        "part": "doekmaat",
        "value": "77,5"
      },
      {
        "unit": "cm",
        "type": "diepte",
        "precision": null,
        "part": "doekmaat",
        "value": "13,5"
      },
      {
        "unit": "kg",
        "type": "gewicht",
        "precision": null,
        "part": "inclusief lijst",
        "value": "31,5"
      }
    ],
    "physicalProperties": [],
    "physicalMedium": "olieverf op doek",
    "longTitle": "De Gele Rijders, George Hendrik Breitner, 1885 - 1886",
    "subTitle": "h 115cm × b 77,5cm × d 13,5cm",
    "scLabelLine": "George Hendrik Breitner (1857–1923), olieverf op doek, 1885–1886",
    "label": {
      "title": "De Gele Rijders",
      "makerLine": "George Hendrik Breitner (1857–1923), olieverf op doek, 1885–1886",
      "description": "In vliegende vaart rijdt het elitekorps van De Gele Rijders van het duin af. Breitner maakte dankbaar gebruik van de zwart met rode hoofddeksels en de gele lissen op de uniformen. De herhaling van deze kleuraccenten versterkt de dynamiek van de beweging. Het opstuivende zand van de voorste paarden vertroebelt het zicht op de volgende rijen. Alleen zwart, geel en rood blijven over.",
      "notes": null,
      "date": "2013-02-01"
    },
    "showImage": true,
    "location": "HG-1.18"
  },
  "artObjectPage": {
    "id": "nl-SK-A-1328",
    "similarPages": [],
    "lang": "nl",
    "objectNumber": "SK-A-1328",
    "tags": [],
    "plaqueDescription": null,
    "audioFile1": null,
    "audioFileLabel1": null,
    "audioFileLabel2": null,
    "createdOn": "0001-01-01T00:00:00",
    "updatedOn": "0001-01-01T00:00:00",
    "adlibOverrides": {
      "titel": null,
      "maker": null,
      "etiketText": null
    }
  }
}
*/
