namespace KanoPlatformDetection {

    public interface IKanoPlatformDetector {

        bool IsKanoDevice();
        
        bool IsKanoPc();
        bool IsKanoPcRetail();
        bool IsKanoPcEducation();

        KanoDevice GetKanoDevice();
        KanoPcSku GetKanoPcSku();
    }
}
