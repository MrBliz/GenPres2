namespace Data

module NormalValueData =

    let ageWeight =
        [
            (0., 3.785)
            (0.7, 3.785)
            (1.4, 4.415)
            (2.1, 5.)
            (2.8, 5.5)
            (4.2, 6.4)
            (6., 7.4)
            (7.4, 8.)
            (9.2, 8.8)
            (11.1, 9.5)
            (12., 9.8)
            (18., 11.5)
            (24., 12.8)
            (30., 14.1)
            (36., 15.2)
            (42., 16.3)
            (48., 17.4)
            (54., 18.5)
            (60., 19.5)
            (66., 20.5)
            (72., 21.6)
            (78., 22.8)
            (84., 24.2)
            (90., 25.5)
            (96., 26.9)
            (102., 28.3)
            (108., 29.8)
            (114., 31.4)
            (120., 33.1)
            (126., 34.9)
            (132., 36.8)
            (138., 38.9)
            (144., 41.2)
            (150., 43.7)
            (156., 46.2)
            (162., 48.9)
            (168., 51.5)
            (174., 54.1)
            (180., 56.4)
            (186., 58.2)
            (192., 59.8)
            (198., 61.1)
            (204., 62.2)
            (210., 63.3)
            (216., 64.2)
            (222., 65.)
            (228., 65.7)
            (234., 66.1)
        ]


    let ageHeight =
        [
            0.6792, 52.95
            3., 52.95
            6., 60.5
            9., 67.25
            12., 71.8
            18., 75.6
            24., 82.3
            30., 88.15
            36., 93.1
            42., 97.6
            48., 101.55
            54., 105.25
            60., 108.8
            66., 112.15
            72., 115.35
            78., 118.55
            84., 121.7
            90., 124.7
            96., 127.7
            102., 130.7
            108., 133.5
            114., 136.2
            120., 139.
            126., 141.8
            132., 144.5
            138., 147.25
            144., 150.15
            150., 153.25
            156., 156.25
            162., 159.05
            168., 161.95
            174., 164.9
            180., 167.45
            186., 169.8
            192., 171.5
            198., 172.55
            204., 173.25
            210., 173.8
            216., 174.2
            222., 174.55
            228., 174.85
            234., 175.05
            240., 175.15            
        ]


    let heartRate =
        [
            1., "90-205"
            12., "90-190"
            36., "80-140"
            72., "65-120"
            144., "58-118"
            180., "50-100"
            228., "50-100"        
        ]    


    let respRate =
        [
            12., "30-53"
            36., "22-37"
            72., "20-28"
            144., "18-25"
            228., "12-20"            
        ]


    let sbp =
        [
            1., "60-84"
            12., "72-104"
            36., "86-106"
            72., "89-112"
            120., "97-115"
            144., "102-120"
            228., "110-131"            
        ]


    let dbp =
        [
            1., "31-53"
            12., "37-56"
            36., "42-63"
            72., "46-72"
            120., "57-76"
            144., "61-80"
            228., "64-83"            
        ]        


    let pews =
        [
            // Age 0 to 3 mo
            3, 
            [ "Ademfrequentie", [(4, "< 15/min"); (2, "15-19/min"); (1, "20-29/min"); (0, "30-60/min"); (1, "61-80/min"); (2, "81-90/min"); (4, "> 90/min")]        
              "Ademarbeid", [(4, ""); (2, ""); (1, ""); (0, "normaal"); (1, "mild verhoogd"); (2, "matig verhoogd"); (4, "ernstig verhoogd")]        
              "Saturatie", [(4, ""); (2, "< 91 %"); (1, "91-94 %"); (0, "> 94%"); (1, ""); (2, ""); (4, "")]        
              "Zuurstof", [(4, ""); (2, ""); (1, ""); (0, "kamerlucht"); (1, ""); (2, "extra O2"); (4, "O2 via NRB of Optiflow")]        
              "Hartfrequentie", [(4, "< 80/min"); (2, "80-89/min"); (1, "90-109/min"); (0, "110-150/min"); (1, "151-180/min"); (2, "181-190/min"); (4, "> 190/min")]        
              "Capillaire refill", [(4, ""); (2, ""); (1, ""); (0, "< 3 sec"); (1, ""); (2, ""); (4, "> 3 sec")]
              "RR (systole)", [(4, "< 45 mmHg"); (2, "45-49 mmHg"); (1, "50-59 mmHg"); (0, "60-80 mmHg"); (1, "81-100 mmHg"); (2, "101-130 mmHg"); (4, "> 130 mmHg")] 
              "Temperatuur", [(4, ""); (2, "< 36.0 C"); (1, "36.0-36.4 C"); (0, "36.5-37.5 C"); (1, "37.6-38.5 C"); (2, "> 38.5 C"); (4, "")]]       
        ]