/**
 * IKanoPlatformDetector.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


namespace KanoComputing.PlatformDetection {

    public interface IKanoPlatformDetector {

        bool IsKanoDevice();

        bool IsKanoPc();
        bool IsKanoPcRetail();
        bool IsKanoPcEducation();

        KanoDevice GetKanoDevice();
        KanoPcSku GetKanoPcSku();
    }
}
