﻿using System;
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
        Console.WriteLine("┏━━━━━━━━━━━━━━━━━┓   ┏━━━━━━━━━━━━━━━━━┓   ┏━━━━━━━━━━━━━━━━━┓   ┏━━━━━━━━━━━━━━━━━┓");

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
        Console.WriteLine("┗━━━━━━━━━━━━━━━━━┛   ┗━━━━━━━━━━━━━━━━━┛   ┗━━━━━━━━━━━━━━━━━┛   ┗━━━━━━━━━━━━━━━━━┛");

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

            /*case 2:
                HuongDanChoi();
                break;*/

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

    static void XuLyChoi()
    {
        Console.Clear();
        Random rand = new Random(); // Đối tượng Random để trộn câu hỏi
        string[,] cauhoi = new string[30, 5] {
 {"Những rác thải nào thuộc nhóm “Rác thải còn lại”?", "A. Túi nilon, hộp xốp, dụng cụ ăn uống gỗ", "B. Hộp sữa giấy, bìa carton", "C. Hộp nhựa, ống hút nhựa", "D. Hộp thực phẩm, đinh, ốc" },
{"Giấy báo, giấy vở, bìa carton thuộc loại rác nào?", "A. Rác thải còn lại", "B. Hộp sữa", "C. Giấy","D. Kim loại" },
{"“Mô hình 3” của UEH Go Green Station gồm:", "A. Chất lỏng, thực phẩm thừa, rác thải còn lại", "B. Thực phẩm thừa, rác tái chế, rác thải còn lại", "C. Chất lỏng, giấy, hộp sữa", "D. Thực phẩm thừa, rác tái chế, chất lỏng" },
{"Trung bình một người Việt Nam thải ra bao nhiêu tấn CO2 mỗi năm?","A. 2 tấn", "B. 3 tấn", "C. 2,5 tấn", "D. 2,3 tấn" },
{"Trước khi xả thải, UEHer, cá nhân ra vào UEH, cần phải làm gì?", "A. Bóc tách rác", "B. Thực hiện cùng lúc phương án A và C", "C. Phân loại rác", "D. Bỏ tất cả vào 1 túi" },
{ "UEHer hay khách vào UEH cần phải tuân thủ nguyên tắc phân loại rác theo mô hình:", "A. Mô hình 4 và 5", "B. Mô hình 5 và 6", "C. Mô hình 3 và 7", "D. Mô hình 5 và 7" },
{ "Hộp thực phẩm làm bằng kim loại sẽ thuộc nhóm nào trong Mô hình 7?", "A. Kim loại", "B. Chất lỏng", "C. Rác thải còn lại", "D. Rác tái chế" },
{ "Loại rác nào dưới đây không thuộc nhóm “Rác tái chế”?", "A. Giấy báo", "B. Chai nhựa", "C. Khẩu trang y tế", "D. Hộp sữa giấy" },
{ "Một chai lọ bị vỡ nên được xử lý như thế nào?", "A. Phân loại vào nhóm Thực phẩm thừa", "B. Bọc kỹ bằng giấy và bỏ vào nhóm Rác thải còn lại", "C. Bỏ trực tiếp vào nhóm Rác thải còn lại", "D. Đập nhỏ thành mảnh vụn trước khi bỏ vào thùng tái chế" },
{ "Những rác thải nào sau đây cần được phân vào nhóm Rác tái chế: ", "A. Chai, lọ nhựa, rác sân vườn", "B. Giấy báo, ly giấy, đinh, ốc", "C. Dụng cụ ăn uống gỗ, ống hút nhựa", "D. Khăn giấy, khẩu trang" },
{ "Khi bạn uống không hết ly matcha latte, phần thừa còn lại trong ly cần được phân loại vào nhóm: ", "A. Rác tái chế", "B. Rác thải còn lại", "C. Giấy", "D. Chất lỏng" },
{ "Loại giấy nào dưới đây được phân loại vào nhóm \"Giấy\" trong mô hình 7? ", "A. Khăn giấy đã qua sử dụng", "B. Giấy báo, sách cũ", "C. Vỏ hộp sữa giấy", "D. Giấy vệ sinh đã qua sử dụng" },
{ "Chất nào sau đây là chất thải khó phân hủy? ", "A. Giấy", "B. Vật chất nhôm", "C. Giấy nhôm", "D. Bông" },
{ "Chất thải động vật có thể chuyển đổi thành… ", "A. Khí tự nhiên", "B. Khí dầu lỏng (LPG)", "C. Khí sinh học", "D. Không có cái nào ở trên" },
{ "Chất thải rắn bao gồm tất cả các loại sau đây, ngoại trừ: ", "A. Báo và chai nước ngọt", "B. Thức ăn thừa và mảnh sân", "C. Ozone và carbon dioxide", "D. Thư rác và hộp sữa" },
{ "Loại chất thải nào phân hủy hoàn toàn khi chôn vào đất? ", "A. Chất thải thực vật", "B. Chất thải nhựa", "C. Chất thải kim loại", "D. Chất thải động vật" },
{ "Rác thải nào sau đây là rác hữu cơ? ", "A. Xương cá", "B. Túi nilon", "C. Pin đã qua sử dụng", "D. Hộp sữa giấy" },
{ "Rác thải nguy hại bao gồm loại nào sau đây? ", "A. Hộp sữa đã qua sử dụng", "B. Pin, ắc quy cũ", "C. Lốp xe cũ", "D. Giấy carton" },
{ "Kim loại phế liệu thuộc loại rác nào? ", "A. Rác thải nguy hại", "B. Rác tái chế", "C. Rác hữu cơ", "D. Rác sinh hoạt không tái chế" },
{ "Bạn đang uống cà phê mang đi và thấy một thùng rác phân loại. Ly cà phê của bạn thuộc loại nào? ", "A. Rác hữu cơ", "B. Rác tái chế (sau khi rửa sạch)", "C. Rác thải nguy hại", "D. Rác thải thông thường" },
{ "Một chiếc áo cũ nhưng vẫn sử dụng được nên làm gì? ","A. Vứt vào thùng rác tái chế", "B. Tặng hoặc tái sử dụng", "C. Vứt chung với rác sinh hoạt", "D. Bỏ vào thùng rác hữu cơ" },
{ "Bạn nên xử lý dầu ăn thừa như thế nào? ", "A. Đổ vào bồn rửa chén", "B. Đổ trực tiếp ra môi trường", "C. Lưu trữ trong chai và giao cho đơn vị xử lý dầu thải", "D. Bỏ vào thùng rác tái chế" },
{ "Pin cũ nếu không được xử lý đúng cách sẽ gây nguy hại gì?", "A. Gây cháy nổ", "B. Ô nhiễm đất và nước", "C. Phát tán kim loại nặng vào môi trường", "D. Tất cả các ý trên" },
{ "Bình xịt (như bình sơn, thuốc diệt côn trùng) thuộc loại rác nào? ", "A. Rác tái chế", "B. Rác thải nguy hại", "C. Rác hữu cơ", "D. Rác sinh hoạt thông thường" },
{ "Giấy thuộc phân loại rác nào trong “Mô hình 3” của UEH Go Green Station? ", "A. Giấy", "B. Rác tái chế", "C. Rác thải còn lại", "D. Nhựa tái chế" },
{ "Tốn bao nhiêu thời gian để phân hủy 1 chai nước làm từ nhựa PET ngoài tự nhiên ", "A. 100 - 500 năm để phân hủy hoàn toàn", "B. 450 - 1000 năm để phân hủy hoàn toàn", "C. 500 năm", "D. 100 năm" },
{ "Quy trình nào sau đây là quy trình tái chế nhựa? ", "A. Nghiền nhỏ, rửa sạch, nấu chảy, ép khuôn", "B. Đốt cháy, lọc khí, làm mát", "C. Phơi nắng, sấy khô, nghiền nát", "D. Rửa sạch, cắt nhỏ, chôn lấp, ủ phân" },
{ "Những vật dụng nào sau đây có thể dùng thủy tinh tái chế để chế tạo? ", "A. Chip máy tính", "B. Giấy", "C. Bê tông", "D. Sơn" },
{ "Nên chọn loại chai nhựa nào dưới đây để có thể sử dụng lại nhiều lần và giảm phát thải? ", "A. Chai nhựa nào cũng như nhau", "B. Chai nhựa PET", "C. Chọn loại chai nhựa rẻ nhất", "D. Chai nhựa HDPE" },
{ "Mô hình nào 3R được áp dụng cho dự án UEH Green Campus để phân loại và xử lý rác gồm các bước nào sau đây: ", "A. Rethink, refuse, reduce", "B. Reduce, reuse, recycle", "C. Rethink, reduce, responsibility", "D. Refuse, reduce, reuse" }
};

        string[] dapAnDung = { "A", "C", "B", "D", "B", "C", "A", "C", "B", "B", "D", "B", "C", "C", "C", "A", "A", "B", "B", "B", "B", "C", "D", "B", "B", "B", "A", "C", "D", "B" }; // Đáp án đúng
        bool daSuDung5050 = false; // Đánh dấu quyền trợ giúp 50/50
        int soCauHoi = cauhoi.GetLength(0); // Lưu số lượng câu hỏi vào biến
        int soVong = 3; // 3 vòng chơi
        int soCauHoiMoiVong = 5; // 5 câu hỏi mỗi vòng

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
                Console.WriteLine("\nCâu hỏi số {0}: {1}", i + 1, cauhoi[i, 0]);
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

                        Console.WriteLine($" {option}");
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
    }
    static int diem = 0;
    static int diemCaoNhat = 0;
    static void KetThucGame()
    {
        Console.Clear();
        Console.WriteLine("\t\t-------------------------------");
        Console.WriteLine("\t\t------ TRÒ CHƠI KẾT THÚC ------");
        Console.WriteLine("\t\t-------------------------------");
        Console.WriteLine($"\t\tĐiểm của bạn là: {diem}");
        if (diem > diemCaoNhat)
        {
            diemCaoNhat = diem;
            Console.WriteLine("\t\tXin chúc mừng bạn đã được 2 điểm rèn luyện\n");
        }
        Console.WriteLine("\t\tNhấn phím Enter để quay lại bảng chọn hoặc nhấn r để chơi lại");
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
