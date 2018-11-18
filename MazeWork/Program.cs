namespace MazeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //객체 생성
            DFS map = new DFS();
            FileManager file = new FileManager(map);
            UserInterface userInterface = new UserInterface(map);

            //맵 불러오기
            file.LoadMap();
            //입출구 찾기
            map.FindInOut();
            map.FindExit();
            //저장
            file.SaveMap();
            //메뉴 출력
            userInterface.DisplayMainMenu();
        }
    }
}
