﻿/**
 * KanoPlatforms.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


namespace KanoComputing.PlatformDetection {

    public enum KanoDevice {
        Unknown = 0,
        KanoPc = 1
    }

    public enum KanoPcSku {
        Unknown = 0,
        Retail = 1,
        Education = 2,
        KPC2002 = 3,
        KPC2005 = 4,
        KPC2007JA = 5,
        KPC2007 = 6,
        KPC2010HS = 7
    }
}
