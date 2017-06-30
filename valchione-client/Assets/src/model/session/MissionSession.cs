public class MissionSession {
    private static MissionSession instance;
    private int _missionId;

    private MissionDto _missionDto;

    private int selectedDeck { get; set; }

    private MissionSession()
    {

    }

    public int missionId
    {
        get { return _missionId; }
        set { _missionId = value; }
    }

    public MissionDto missionDto
    {
        get { return _missionDto; }
        set { _missionDto = value; }
    }

    public static MissionSession getInstance()
    {
        if (instance == null) instance = new MissionSession();
        return instance;
    }


}
