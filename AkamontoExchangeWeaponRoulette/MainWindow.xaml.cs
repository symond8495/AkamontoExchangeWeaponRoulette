using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace AkamontoExchangeWeaponRoulette
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<List<string>> weaponCategorys;
        private List<string> weaponCategoryNameList;
        private List<string> shooter;
        private List<string> roller;
        private List<string> charger;
        private List<string> slosher;
        private List<string> spinner;
        private List<string> maneuver;
        private List<string> shelter;
        private List<string> blaster;
        private List<string> brusher;
        private List<string> stringer;
        private List<string> wiper;
        private List<TextBox> PlayerUsingWeaponTextBoxList;
        private List<TextBlock> PlayerUsingWeaponCategoryTextBlockList;

        public MainWindow()
        {
            InitializeComponent();

            this.PlayerUsingWeaponTextBoxList = new List<TextBox>();
            this.PlayerUsingWeaponCategoryTextBlockList = new List<TextBlock>();
            this.weaponCategoryNameList = new List<string>();
            this.weaponCategorys = new List<List<string>>();
            this.PeopleCount.SelectedIndex = 3;

            this.shooter = new List<string>
            {
                "ボールドマーカー",
                "ボールドマーカーネオ",
                "わかばシューター",
                "もみじシューター",
                "シャープマーカー",
                "シャープマーカーネオ",
                "プロモデラーMG",
                "プロモデラーRG",
                "スプラシューター",
                "スプラシューターコラボ",
                ".52ガロン",
                ".52ガロンデコ",
                "N-ZAP85",
                "N-ZAP89",
                "プライムシューター",
                "プライムシューターコラボ",
                ".96ガロン",
                ".96ガロンデコ",
                "ジェットスイーパー",
                "ジェットスイーパーカスタム",
                "L3リールガン",
                "L3リールガンD",
                "H3リールガン",
                "H3リールガンD",
                "ボトルガイザー",
                "ボトルガイザーフォイル",
                "スペースシューター",
                "スペースシューターコラボ"
            };
            this.roller = new List<string>
            {
                "カーボンローラー",
                "カーボンローラーデコ",
                "スプラローラー",
                "スプラローラーコラボ",
                "ダイナモローラー",
                "ダイナモローラーテスラ",
                "ヴァリアブルローラー",
                "ヴァリアブルローラーフォイル",
                "ワイドローラー",
                "ワイドローラーコラボ"
            };
            this.charger = new List<string>
        {
            "スクイックリンα",
            "スクイックリンβ",
            "スプラチャージャー",
            "スプラチャージャーコラボ",
            "スプラスコープ",
            "スプラスコープコラボ",
            "リッター4K",
            "4Kスコープ",
            "リッター4Kカスタム",
            "4Kスコープカスタム",
            "14式竹筒銃・甲",
            "14式竹筒銃・乙",
            "ソイチューバー",
            "ソイチューバーカスタム",
            "R-PEN/5H",
            "R-PEN/5B"
        };
            this.slosher = new List<string>
            {
                "バケットスロッシャー",
                "バケットスロッシャーデコ",
                "ヒッセン",
                "ヒッセン・ヒュー",
                "スクリュースロッシャー",
                "スクリュースロッシャーネオ",
                "オーバーフロッシャー",
                "オーバーフロッシャーデコ",
                "エクスプロッシャー",
                "エクスプロッシャーカスタム",
                "モップリン",
                "モップリンD"
            };
            this.spinner = new List<string>
        {
            "スプラスピナー",
            "スプラスピナーコラボ",
            "バレルスピナー",
            "バレルスピナーデコ",
            "ハイドラント",
            "ハイドラントカスタム",
            "クーゲルシュライバー",
            "クーゲルシュライバー・ヒュー",
            "ノーチラス47",
            "ノーチラス79",
            "イグザミナー",
            "イグザミナー・ヒュー"
        };
            this.maneuver = new List<string>
            {
                "スパッタリー",
                "スパッタリー・ヒュー",
                "スプラマニューバー",
                "スプラマニューバーコラボ",
                "ケルビン525",
                "ケルビン525デコ",
                "デュアルスイーパー",
                "デュアルスイーパーカスタム",
                "クアッドホッパーブラック",
                "クアッドホッパーホワイト",
                "ガエンFF",
                "ガエンFFカスタム"
            };
            this.shelter = new List<string>
        {
            "パラシェルター",
            "パラシェルターソレーラ",
            "キャンピングシェルター",
            "キャンピングシェルターソレーラ",
            "スパイガジェット",
            "スパイガジェットソレーラ",
            "24式張替傘・甲",
            "24式張替傘・乙"
        };
            this.blaster = new List<string>
            {
                "ノヴァブラスター",
                "ノヴァブラスターネオ",
                "ホットブラスター",
                "ホットブラスターカスタム",
                "ロングブラスター",
                "ロングブラスターカスタム",
                "クラッシュブラスター",
                "クラッシュブラスターネオ",
                "ラピッドブラスター",
                "ラピッドブラスターデコ",
                "Rブラスターエリート",
                "Rブラスターエリートデコ",
                "S-BLAST92",
                "S-BLAST91"
            };
            this.brusher = new List<string>
            {
                "パブロ",
                "パブロ・ヒュー",
                "ホクサイ",
                "ホクサイ・ヒュー",
                "フィンセント",
                "フィンセント・ヒュー"
            };
            this.stringer = new List<string>
        {
            "トライストリンガー",
            "トライストリンガーコラボ",
            "LACT-450",
            "LACT-450デコ",
            "フルイドV",
            "フルイドVカスタム"
        };
            this.wiper = new List<string>
        {
            "ジムワイパー",
            "ジムワイパー・ヒュー",
            "ドライブワイパー",
            "ドライブワイパーデコ",
            "デンタルワイパーミント",
            "デンタルワイパースミ"
        };
            this.ResetWeaponCategorys();

            this.CreateWeaponTextBlock();
        }

        private void ResetWeaponCategorys()
        {
            this.weaponCategoryNameList.Clear();
            this.weaponCategoryNameList = new List<string>()
            {
                "シューター",
                "ローラー",
                "チャージャー",
                "バケツ",
                "スピナー",
                "マニューバー",
                "シェルター",
                "ブラスター",
                "フデ",
                "ストリンガー",
                "ワイパー"
            };
            this.weaponCategorys.Clear();
            this.weaponCategorys.Add(this.shooter);
            this.weaponCategorys.Add(this.roller);
            this.weaponCategorys.Add(this.charger);
            this.weaponCategorys.Add(this.slosher);
            this.weaponCategorys.Add(this.spinner);
            this.weaponCategorys.Add(this.maneuver);
            this.weaponCategorys.Add(this.shelter);
            this.weaponCategorys.Add(this.blaster);
            this.weaponCategorys.Add(this.brusher);
            this.weaponCategorys.Add(this.stringer);
            this.weaponCategorys.Add(this.wiper);
        }

        private void CreateWeaponTextBlock()
        {
            StackPanel teamWeapon = this.TeamWeapon;
            StackPanel teamWeaponCategory = this.TeamWeaponCategory;

            teamWeapon.Children.Clear();
            teamWeaponCategory.Children.Clear();
            this.PlayerUsingWeaponTextBoxList.Clear();
            this.PlayerUsingWeaponCategoryTextBlockList.Clear();

            TextBox weaponTextBox = new TextBox();
            TextBlock weaponCategoryTextBlock = new TextBlock();
            for (int j = 0; j < int.Parse(PeopleCount.Text); j++)
            {
                weaponTextBox = new TextBox();
                weaponCategoryTextBlock = new TextBlock();
                weaponTextBox.Margin = new Thickness(0, 5, 0, 0);
                weaponCategoryTextBlock.Margin = new Thickness(2, 5, 0, 0);
                weaponCategoryTextBlock.Height = 18;
                weaponCategoryTextBlock.Text = "未設定";
                this.PlayerUsingWeaponTextBoxList.Add(weaponTextBox);
                this.PlayerUsingWeaponCategoryTextBlockList.Add(weaponCategoryTextBlock);
                this.TeamWeapon.Children.Add(weaponTextBox);
                this.TeamWeaponCategory.Children.Add(weaponCategoryTextBlock);
            }
        }
        private void PeopleCount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Task.Run(() =>
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    string oldText = ((ComboBox)sender).Text;
                    this.Dispatcher.Invoke((Action)(async () =>
                    {
                        while (true)
                        {
                            if (oldText != ((ComboBox)sender).Text)
                            {
                                break;
                            }
                            await Task.Delay(1);
                        }
                    }));
                    Debug.WriteLine(((ComboBox)sender).Text);
                    CreateWeaponTextBlock();
                }));
            });
        }
        private void SetTextStatusBar(string timer)
        {
            this.LogStatus.Text = $"最終ルーレット: {DateTime.Now}";
            this.TimeTextBox.Text = timer ;
        }
        private void WeaponMethod()
        {
            Random random = new Random();
            for (int count = 0; count < int.Parse(this.PeopleCount.Text); count++)
            {
                int categoryNumber = random.Next(this.weaponCategoryNameList.Count);
                List<string> weaponCategory = this.weaponCategorys[categoryNumber];
                string selectedWeapon = weaponCategory[random.Next(weaponCategory.Count)];
                this.PlayerUsingWeaponTextBoxList[count].Text = selectedWeapon;
                this.PlayerUsingWeaponCategoryTextBlockList[count].Text = this.weaponCategoryNameList[categoryNumber];
                this.weaponCategoryNameList.RemoveRange(categoryNumber, 1);
                this.weaponCategorys.RemoveRange(categoryNumber, 1);
            }
            this.ResetWeaponCategorys();
        }
        private void CategoryMethod()
        {
            List<string> weaponList = new List<string>();
            Dictionary<string, int> weaponListIndexLine = new Dictionary<string, int>();
            foreach (var item in this.weaponCategorys.Select((list, index) => new { list, index }))
            {
                weaponList.AddRange(item.list);
                foreach (var weapon in item.list)
                {
                    weaponListIndexLine[weapon] = item.index;
                }
            }
            bool isDecided = false;
            while (!isDecided)
            {
                List<int> teamCategoryNumberList = new List<int>();
                List<string> organization = new List<string>();
                Random random = new Random();
                for (int count = 0; count < int.Parse(this.PeopleCount.Text); count++)
                {
                    int weaponNumber = random.Next(weaponList.Count);
                    string selectedWeapon = weaponList[weaponNumber];
                    int categoryNumber = weaponListIndexLine[weaponList[weaponNumber]];
                    teamCategoryNumberList.Add(categoryNumber);
                    organization.Add(weaponList[weaponNumber]);

                    this.PlayerUsingWeaponTextBoxList[count].Text = selectedWeapon;
                    this.PlayerUsingWeaponCategoryTextBlockList[count].Text = this.weaponCategoryNameList[categoryNumber];
                }
                var hashset = new HashSet<int>();
                bool isCompetitor = false;
                foreach (var categoryNumber in teamCategoryNumberList)
                {
                    if (hashset.Add(categoryNumber) == false)
                    {
                        isCompetitor = true;
                    }
                }
                if (!isCompetitor)
                {
                    isDecided = true;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            StackPanel teamWeaponCategory = this.TeamWeaponCategory;
            int tryCount = 10000;

            if ((bool)this.WeaponRadio.IsChecked)
            {
                sw.Start();
                for (int i = 0; i != tryCount; i++)
                {
                    WeaponMethod();
                }
                sw.Stop();
            }
            else
            {
                sw.Start();
                for (int i = 0; i != tryCount; i++)
                {
                    CategoryMethod();
                }
                sw.Stop();
            }

            this.SetTextStatusBar(sw.Elapsed.ToString());
        }
    }
}
