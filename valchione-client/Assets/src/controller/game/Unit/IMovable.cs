public interface IMovable {
    int movement { get; set; }
    bool moved { get; set; }

    void confirmMove();
    void refreshMove();

}
