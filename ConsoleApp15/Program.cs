using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
class Program
{
    static Dictionary<string, List<int>> playerScores = new Dictionary<string, List<int>>();
    static string nguoichoi = string.Empty;

    static void Main()
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        NameGame();
        string message = "Nhấn phím bất kỳ để tiếp tục...";
        Print((Console.BufferWidth - message.Length) / 2,
              Console.BufferHeight / 2 + 7,
              message,
              ConsoleColor.DarkRed);

        Console.ReadKey(true);
        while (true)
        {
            Console.Clear();
            ShowMenu();
        }
    }
    public static void NameGame()
    {
        string[] Name = new string[]
        {
                @" _______   ___                            ___                                      _______                          ",
                @"/ $$$$$ \  $$|                            $$|                             ___     /$$$$$$$\                            ",
                @"$$     $ | $$|                            $$|                            /$$$\    $$      $|                            ",
                @"$$     $$| $$|                            $$|                            \$$$/    $$ $$$$ $|                            ",
                @"$$ $$$ $$| $$|___    ______     ______    $$|        ______     ______    __      $$ _____/    ______      ______   ",
                @"$$ _____/  $$ $$$\  / $$$$$|   /$$$ $$\   $$|       / $$$$ \   / $$$$$|   $$|     $$ | $$$\   / $$$$$|   /$$$$$$/    ",
                @"$$ |       $$ __$| $$$   $$|_   $$__ $|   $$|       $$    $$| $$$   $$|_  $$|     $$ |   $$\ $$$   $$|_  $$  --    ",
                @"$$ |       $$ | $|  $$    $$|$| $$|  $|   $$|____   $$    $$| $$    $$$|$ $$|     $$ |    $$\ $$    $$$| $$$|____   ",
                @"$$ |       $$ | $|   $$$$$$$ /  $$/  $/   $$$$$$$$$  $$$$$ /   $$$$$$$ /  $$|     $$ |      $\ $$$$$$$/   \$$$$$$\   ",
        };

        Print((Console.BufferWidth - Name[0].Length) / 2,
              Math.Max(0, Console.BufferHeight / 2 - 6),
              Name,
              ConsoleColor.DarkGreen);
    }

    public static void Print(int x, int y, string text, ConsoleColor color)
    {
        if (x < 0 || y < 0 || y >= Console.BufferHeight) return;

        Console.SetCursorPosition(Math.Max(0, x), y);
        Console.ForegroundColor = color;
        Console.Write(text.Length > Console.BufferWidth ? text.Substring(0, Console.BufferWidth) : text);
        Console.ResetColor();
    }

    public static void Print(int x, int y, string[] text, ConsoleColor color)
    {
        for (int i = 0; i < text.Length; i++)
        {
            if (y + i >= Console.BufferHeight) break;

            string line = text[i].Length > Console.BufferWidth
                          ? text[i].Substring(0, Console.BufferWidth) : text[i];

            Console.SetCursorPosition(Math.Max(0, x), y + i);
            Console.ForegroundColor = color;
            Console.Write(line);
        }
        Console.ResetColor();
    }

    static void ShowMenu()
    {
        Console.Clear();

        // Tính toán vị trí y bắt đầu và x để căn giữa
        int yStart = (Console.BufferHeight - 3) / 2; // 3 dòng menu
        int xStart = (Console.BufferWidth - 73) / 2; // Độ dài chuỗi dài nhất là 73 ký tự

        // Định nghĩa các màu cho từng chức năng
        ConsoleColor[] colors = { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.Red };

        // In dòng trên cùng của menu
        Console.SetCursorPosition(xStart, yStart);
        //Console.WriteLine("┏━━━━━━━━━━━━━━━━━┓   ┏━━━━━━━━━━━━━━━━━┓   ┏━━━━━━━━━━━━━━━━━┓   ┏━━━━━━━━━━━━━━━━━┓");
        Console.ForegroundColor = colors[0];
        Console.Write("┏━━━━━━━━━━━━━━━━━┓   ");
        Console.ForegroundColor = colors[1];
        Console.Write("┏━━━━━━━━━━━━━━━━━┓   ");
        Console.ForegroundColor = colors[2];
        Console.Write("┏━━━━━━━━━━━━━━━━━┓   ");
        Console.ForegroundColor = colors[3];
        Console.WriteLine("┏━━━━━━━━━━━━━━━━━┓   ");
        Console.ResetColor();
        
        // In dòng giữa với từng màu cho chức năng
        Console.SetCursorPosition(xStart, yStart + 1);
        Console.ForegroundColor = colors[0];
        Console.Write("┃ 1. Bắt đầu chơi ┃   ");
        Console.ForegroundColor = colors[1];
        Console.Write("┃  2. Hướng dẫn   ┃   ");
        Console.ForegroundColor = colors[2];
        Console.Write("┃ 3. Cài đặt nhạc ┃   ");
        Console.ForegroundColor = colors[3];
        Console.WriteLine("┃    4. Thoát     ┃");
        Console.ResetColor();

        // In dòng dưới cùng của menu

        Console.SetCursorPosition(xStart, yStart + 2);
        //Console.WriteLine("┗━━━━━━━━━━━━━━━━━┛   ┗━━━━━━━━━━━━━━━━━┛   ┗━━━━━━━━━━━━━━━━━┛   ┗━━━━━━━━━━━━━━━━━┛");
        Console.ForegroundColor = colors[0];
        Console.Write("┗━━━━━━━━━━━━━━━━━┛   ");
        Console.ForegroundColor = colors[1];
        Console.Write("┗━━━━━━━━━━━━━━━━━┛   ");
        Console.ForegroundColor = colors[2];
        Console.Write("┗━━━━━━━━━━━━━━━━━┛   ");
        Console.ForegroundColor = colors[3];
        Console.WriteLine("┗━━━━━━━━━━━━━━━━━┛   ");
        Console.ResetColor();
        // In lời nhắc nhập lựa chọn bên dưới menu
        string prompt = "Mời bấm phím để lựa chọn: ";
        int promptX = (Console.BufferWidth - prompt.Length) / 2;
        Console.SetCursorPosition(promptX, yStart + 4);
        Console.Write(prompt);

        // Xử lý nhập lựa chọn
        int choice;
        try
        {
            choice = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Vui lòng nhập một số nguyên hợp lệ.");
            Console.WriteLine("Ấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
            return;
        }

        switch (choice)
        {
            case 1:
                NhapThongTin();
                break;

            case 2:
                HuongDanChoi();
                break;

            case 3:
                Console.WriteLine("Cài đặt nhạc chưa được triển khai.");
                Console.WriteLine("Ấn phím bất kỳ để quay lại menu chính...");
                Console.ReadKey();
                break;

            case 4:
                Environment.Exit(0);
                break;

            default:
                Console.WriteLine("Phím bấm không hợp lệ");
                Console.WriteLine("Ấn phím bất kỳ để quay lại menu chính...");
                Console.ReadKey();
                break;
        }
    }

    static void NhapThongTin()
    {
        Console.Clear();
        Console.Write("Nhập tên người chơi: ");
        nguoichoi = Console.ReadLine();

        if (!playerScores.ContainsKey(nguoichoi))
        {
            playerScores[nguoichoi] = new List<int>();
        }

        Console.WriteLine($"Chào mừng {nguoichoi} đến với game!");
        Console.WriteLine("Nhấn phím bất kỳ để bắt đầu game hoặc ESC để quay lại menu chính.");

        while (true)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Escape)
            {
                return;
            }
            else
            {
                XuLyChoi();
                break;
            }
        }
    }
    static void HuongDanChoi()
    {
        Console.Clear();
        Console.WriteLine("\t\tHƯỚNG DẪN");
        Console.WriteLine("Khi bạn bấm vào chơi thì máy sẽ ngẫu nhiên đưa ra 1 câu hỏi trong bộ câu hỏi có sẵn. ");
        Console.WriteLine("Sau đó bạn sẽ suy nghĩ và chọn đáp án đúng.");
        Console.WriteLine("Do đây là mô hình phân loại 7 nên sẽ quy ước: \r\n1. Chất lỏng\r\n2. Thực phẩm thừa\r\n3. Kim loại\r\n4. Nhựa tái chế\r\n5. Giấy\r\n6. Hộp sữa \r\n7. Rác thải còn lại. \r\n");
        Console.WriteLine("1 round sẽ gồm 5 phút để chơi: trả lời đúng 1 câu sẽ được 1 điểm");
        Console.WriteLine("NHỚ TẮT BỘ GÕ TIẾNG VIỆT TRƯỚC KHI CHƠI");
        Console.WriteLine("\nNhấn ESC để thoát hướng dẫn");

        while (Console.ReadKey().Key != ConsoleKey.Escape) ;

    }
    static int diemCaoNhat = 0;
    static void XuLyChoi()
    {
        Console.Clear();
        Random rand = new Random(); // Đối tượng Random để trộn câu hỏi
        string[,] cauhoi = new string[30, 5] {
     {"Những rác thải nào thuộc nhóm “Rác thải còn lại”?", "Túi nilon, hộp xốp, dụng cụ ăn uống gỗ", "Hộp sữa giấy, bìa carton", "Hộp nhựa, ống hút nhựa", "Hộp thực phẩm, đinh, ốc" },
    {"Giấy báo, giấy vở, bìa carton thuộc loại rác nào?", "Rác thải còn lại", "Hộp sữa", "Giấy","Kim loại" },
    {"“Mô hình 3” của UEH Go Green Station gồm:", "Chất lỏng, thực phẩm thừa, rác thải còn lại", "Thực phẩm thừa, rác tái chế, rác thải còn lại", "Chất lỏng, giấy, hộp sữa", "Thực phẩm thừa, rác tái chế, chất lỏng" },
    {"Trung bình một người Việt Nam thải ra bao nhiêu tấn CO2 mỗi năm?","2 tấn", "3 tấn", "2,5 tấn", "2,3 tấn" },
    {"Trước khi xả thải, UEHer, cá nhân ra vào UEH, cần phải làm gì?", "Bóc tách rác", "Thực hiện cùng lúc phương án A và C", "Phân loại rác", "Bỏ tất cả vào 1 túi" },
    { "UEHer hay khách vào UEH cần phải tuân thủ nguyên tắc phân loại rác theo mô hình:", "Mô hình 4 và 5", "Mô hình 5 và 6", "Mô hình 3 và 7", "Mô hình 5 và 7" },
    { "Hộp thực phẩm làm bằng kim loại sẽ thuộc nhóm nào trong Mô hình 7?", "Kim loại", "Chất lỏng", "Rác thải còn lại", "Rác tái chế" },
    { "Loại rác nào dưới đây không thuộc nhóm “Rác tái chế”?", "Giấy báo", "Chai nhựa", "Khẩu trang y tế", "Hộp sữa giấy" },
    { "Một chai lọ bị vỡ nên được xử lý như thế nào?", "Phân loại vào nhóm Thực phẩm thừa", "Bọc kỹ bằng giấy và bỏ vào nhóm Rác thải còn lại", "Bỏ trực tiếp vào nhóm Rác thải còn lại", "Đập nhỏ thành mảnh vụn trước khi bỏ vào thùng tái chế" },
    { "Những rác thải nào sau đây cần được phân vào nhóm Rác tái chế: ", "Chai, lọ nhựa, rác sân vườn", "Giấy báo, ly giấy, đinh, ốc", "Dụng cụ ăn uống gỗ, ống hút nhựa", "Khăn giấy, khẩu trang" },
    { "Khi bạn uống không hết ly matcha latte, phần thừa còn lại trong ly cần được phân loại vào nhóm: ", "Rác tái chế", "Rác thải còn lại", "Giấy", "Chất lỏng" },
    { "Loại giấy nào dưới đây được phân loại vào nhóm \"Giấy\" trong mô hình 7? ", "Khăn giấy đã qua sử dụng", "Giấy báo, sách cũ", "Vỏ hộp sữa giấy", "Giấy vệ sinh đã qua sử dụng" },
    { "Chất nào sau đây là chất thải khó phân hủy? ", "Giấy", "Vật chất nhôm", "Giấy nhôm", "Bông" },
    { "Chất thải động vật có thể chuyển đổi thành… ", "Khí tự nhiên", "Khí dầu lỏng (LPG)", "Khí sinh học", "Không có cái nào ở trên" },
    { "Chất thải rắn bao gồm tất cả các loại sau đây, ngoại trừ: ", "Báo và chai nước ngọt", "Thức ăn thừa và mảnh sân", "Ozone và carbon dioxide", "Thư rác và hộp sữa" },
    { "Loại chất thải nào phân hủy hoàn toàn khi chôn vào đất? ", "Chất thải thực vật", "Chất thải nhựa", "Chất thải kim loại", "Chất thải động vật" },
    { "Rác thải nào sau đây là rác hữu cơ? ", "Xương cá", "Túi nilon", "Pin đã qua sử dụng", "Hộp sữa giấy" },
    { "Rác thải nguy hại bao gồm loại nào sau đây? ", "Hộp sữa đã qua sử dụng", "Pin, ắc quy cũ", "Lốp xe cũ", "Giấy carton" },
    { "Kim loại phế liệu thuộc loại rác nào? ", "Rác thải nguy hại", "Rác tái chế", "Rác hữu cơ", "Rác sinh hoạt không tái chế" },
    { "Bạn đang uống cà phê mang đi và thấy một thùng rác phân loại. Ly cà phê của bạn thuộc loại nào? ", "Rác hữu cơ", "Rác tái chế (sau khi rửa sạch)", "Rác thải nguy hại", "Rác thải thông thường" },
    { "Một chiếc áo cũ nhưng vẫn sử dụng được nên làm gì? ","Vứt vào thùng rác tái chế", "Tặng hoặc tái sử dụng", "Vứt chung với rác sinh hoạt", "Bỏ vào thùng rác hữu cơ" },
    { "Bạn nên xử lý dầu ăn thừa như thế nào? ", "Đổ vào bồn rửa chén", "Đổ trực tiếp ra môi trường", "Lưu trữ trong chai và giao cho đơn vị xử lý dầu thải", "Bỏ vào thùng rác tái chế" },
    { "Pin cũ nếu không được xử lý đúng cách sẽ gây nguy hại gì?", "Gây cháy nổ", "Ô nhiễm đất và nước", "Phát tán kim loại nặng vào môi trường", "Tất cả các ý trên" },
    { "Bình xịt (như bình sơn, thuốc diệt côn trùng) thuộc loại rác nào? ", "Rác tái chế", "Rác thải nguy hại", "Rác hữu cơ", "Rác sinh hoạt thông thường" },
    { "Giấy thuộc phân loại rác nào trong “Mô hình 3” của UEH Go Green Station? ", "Giấy", "Rác tái chế", "Rác thải còn lại", "Nhựa tái chế" },
    { "Tốn bao nhiêu thời gian để phân hủy 1 chai nước làm từ nhựa PET ngoài tự nhiên ", "100 - 500 năm để phân hủy hoàn toàn", "450 - 1000 năm để phân hủy hoàn toàn", "500 năm", "100 năm" },
    { "Quy trình nào sau đây là quy trình tái chế nhựa? ", "Nghiền nhỏ, rửa sạch, nấu chảy, ép khuôn", "Đốt cháy, lọc khí, làm mát", "Phơi nắng, sấy khô, nghiền nát", "Rửa sạch, cắt nhỏ, chôn lấp, ủ phân" },
    { "Những vật dụng nào sau đây có thể dùng thủy tinh tái chế để chế tạo? ", "Chip máy tính", "Giấy", "Bê tông", "Sơn" },
    { "Nên chọn loại chai nhựa nào dưới đây để có thể sử dụng lại nhiều lần và giảm phát thải? ", "Chai nhựa nào cũng như nhau", "Chai nhựa PET", "Chọn loại chai nhựa rẻ nhất", "Chai nhựa HDPE" },
    { "Mô hình nào 3R được áp dụng cho dự án UEH Green Campus để phân loại và xử lý rác gồm các bước nào sau đây: ", "Rethink, refuse, reduce", "Reduce, reuse, recycle", "Rethink, reduce, responsibility", "Refuse, reduce, reuse" }
    };

        string[] dapAnDung = { "A", "C", "B", "D", "B", "C", "A", "C", "B", "B", "D", "B", "C", "C", "C", "A", "A", "B", "B", "B", "B", "C", "D", "B", "B", "B", "A", "C", "D", "B" }; // Đáp án đúng
        bool daSuDung5050 = false; // Đánh dấu quyền trợ giúp 50/50
        int soCauHoi = cauhoi.GetLength(0); // Lưu số lượng câu hỏi vào biến
        int soVong = 3; // 3 vòng chơi
        int soCauHoiMoiVong = 5; // 5 câu hỏi mỗi vòng
        int tongDiem = 0; 
        // Quá trình chơi
        for (int vong = 1; vong <= soVong; vong++)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n--- Vòng {vong} ---");
            List<string> cauHoiCuaVong = new List<string>();

            int diem = 0;
            int diemTungVong = 0;
            int soThuTu = 1;
            List<int> indexList = Enumerable.Range(0, soCauHoi).OrderBy(x => rand.Next()).ToList();
            for (int i = 0; i < soCauHoiMoiVong; i++)
            {
                //List<int> indexList = Enumerable.Range(0, soCauHoi).OrderBy(x => rand.Next()).ToList();
                int index = indexList[i]; // Lấy chỉ số câu hỏi đã trộn
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nCâu hỏi số {0}: {1}", i + 1, cauhoi[index, 0]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");

                /*Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("A. {0}", cauhoi[i, 1].PadRight(50)}                                                  ");
                Console.WriteLine($"    B.  {cauHoi.DapAn[1].PadRight(50)}                                                  ");
                Console.WriteLine($"    C.  {cauHoi.DapAn[2].PadRight(50)}                                                  ");
                Console.WriteLine($"    D.  {cauHoi.DapAn[3].PadRight(50)}                                                  ");
                Console.ResetColor();
                Console.WriteLine($"╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");*/

                // Tạo danh sách chỉ số câu hỏi (0, 1, 2, ..., 29)
                //List<int> indexList = new List<int>();
                //for (int i = 0; i < soCauHoi; i++)
                //{
                //indexList.Add(i);
                //}

                // Trộn danh sách chỉ số câu hỏi
                //indexList = indexList.OrderBy(x => rand.Next()).ToList();

                //for (int i = 0; i < soCauHoi; i++)
                //{
                //int index = indexList[i]; // Lấy chỉ số câu hỏi đã trộn
                //Console.WriteLine("\nCâu hỏi số {0}: {1}", i + 1, cauhoi[index, 0]);

                //List<string> luachon = options.OrderBy(x => rand.Next()).ToList();
                Console.WriteLine("A. {0}", cauhoi[index, 1]);
                Console.WriteLine("B. {0}", cauhoi[index, 2]);
                Console.WriteLine("C. {0}", cauhoi[index, 3]);
                Console.WriteLine("D. {0}", cauhoi[index, 4]);

                string chon5050 = " ";
                while (true)
                {
                    // Hỏi người chơi xem có muốn sử dụng 50/50 không
                    try
                    {
                        Console.WriteLine("\nBạn có muốn sử dụng quyền trợ giúp 50/50 không? (Y/N)");
                        chon5050 = Console.ReadLine()?.ToUpper();
                        if (chon5050 == "Y" || chon5050 == "N")
                            break;
                        else
                            throw new Exception("Mời bạn nhập đúng Y hoặc N");
                    }
                    catch (Exception loi)
                    {
                        Console.WriteLine(loi.Message);
                    }
                }

                if (chon5050 == "Y")
                {
                    daSuDung5050 = true;

                    // Sử dụng quyền trợ giúp 50/50
                    List<string> options = new List<string> { cauhoi[index, 1], cauhoi[index, 2], cauhoi[index, 3], cauhoi[index, 4] };
                    string correctAnswer = cauhoi[index, dapAnDung[index] == "A" ? 1 : (dapAnDung[index] == "B" ? 2 : (dapAnDung[index] == "C" ? 3 : 4))];

                    UseFiftyFifty(options, correctAnswer);

                    // Hiển thị lại câu hỏi với 2 đáp án còn lại
                    Console.WriteLine("\nSau khi sử dụng quyền trợ giúp 50/50:");
                    DisplayOptions(options);
                }
                else if (chon5050 == "Y")
                {
                    Console.WriteLine("Bạn đã sử dụng quyền trợ giúp 50/50 trước đó.");
                }

                Console.Write("\nNhập câu trả lời của bạn (A/B/C/D): ");
                string traloi = Console.ReadLine()?.ToUpper();

                if (traloi == dapAnDung[index])
                {
                    Console.WriteLine("Bạn đã chọn đáp án đúng.");
                    diem++;
                }
                else
                {
                    Console.WriteLine("Sai rồi. Đáp án đúng là: {0}.", dapAnDung[index]);
                }
                //}
            }
            diemTungVong += diem;
            Console.WriteLine("\nBạn đã hoàn thành vòng {0} với số điểm: {1}/{2}", vong, diem, soCauHoiMoiVong);
            //Cộng điểm của vòng hiện tại vào tồng điểm
            tongDiem += diem;
            // Hàm trợ giúp để hiển thị các lựa chọn
            static void DisplayOptions(List<string> options)
            {
                char optionLetter = 'A'; // Đánh dấu các lựa chọn từ A, B, C, D
                /*for (int i = 0; i < options.Count; i++)
                {
                    if (!string.IsNullOrEmpty(options[i]))
                    {
                        Console.WriteLine($"{optionLetter}. {options[i]}");
                    }
                    optionLetter++;
                }*/
                foreach (var option in options)
                {
                    if (!string.IsNullOrEmpty(option))
                    {

                        Console.WriteLine($"{optionLetter}. {option}");
                        optionLetter++;
                    }
                }
            }

            // Hàm trợ giúp để sử dụng quyền trợ giúp 50/50
            static void UseFiftyFifty(List<string> options, string correctAnswer)
            {
                // Xóa 2 câu trả lời sai (giữ lại câu trả lời đúng và 1 câu sai)
                List<string> wrongAnswers = options.Where(x => x != correctAnswer).OrderBy(x => Guid.NewGuid()).Take(2).ToList();
                foreach (var wrongAnswer in wrongAnswers)
                {
                    options.Remove(wrongAnswer);
                }
            }
        }
        // Sau khi trò chơi kết thúc, gọi hàm KetThucGame
        Console.ReadKey();
        KetThucGame(tongDiem);
    }
    //static int diem = 0;
    //atic int diemCaoNhat = 0;
    static void KetThucGame(int tongDiem)
    {
        Console.Clear();
        Console.WriteLine("\t\t-------------------------------");
        Console.WriteLine("\t\t|      TRÒ CHƠI KẾT THÚC       |");
        Console.WriteLine("\t\t-------------------------------");
        Console.WriteLine($"\t\tĐiểm của bạn là: {tongDiem}");
        if (tongDiem > 10)
        {
            diemCaoNhat = tongDiem;
            Console.WriteLine("\t\tXin chúc mừng bạn đã được 2 điểm rèn luyện\n");
        }
        else Console.WriteLine("\t\tRất tiếc. Bạn không được nhận 2 điểm rèn luyện. Nhấn phím Enter để quay lại bảng chọn hoặc nhấn r để chơi lại");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\t\tĐIỂM CAO NHẤT: {diemCaoNhat}");
        Console.ResetColor();

        bool nenThoat = false;

        while (!nenThoat)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    nenThoat = true;
                    break;
                default:
                    if (keyInfo.KeyChar == 'r' || keyInfo.KeyChar == 'R') // Chơi lại
                    {
                        XuLyChoi();
                        nenThoat = true;
                    }
                    break;
            }
        }

    }
}

