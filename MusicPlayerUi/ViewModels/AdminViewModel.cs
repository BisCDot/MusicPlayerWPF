using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicPlayer.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {
        public string SourceMedia { get; set; }

        public List<string> listPlayers { get; set; }

        public ObservableCollection<ItemSong> ListSounds { get; set; }
        private ItemSong _selectedAudio;

        public AdminViewModel()
        {
            NextCommand = new RelayCommand(NextCommandInvoke);
            PrevCommand = new RelayCommand(PrevCommandInvoke);
            SourceMedia = @"http://api.mp3.zing.vn/api/streaming/audio/ZZCZCCED/320";
            ListSounds = new ObservableCollection<ItemSong>
            {
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZCZCCED/320", NameMusic = "Con Nhà Quê        ",Time = "03:50", Number ="1" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZDA60O8/320", NameMusic = "Một Ngàn Nỗi Đau  ",Time = "05:22", Number ="2" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZ98CW7W/320", NameMusic = "Hàng Xóm          ",Time = "04:04", Number = "3" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZDI9B7U/320", NameMusic = "Vì Mẹ Bắt Chia Tay",Time = "04:22", Number = "4" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZDWA6AE/320", NameMusic = "Thiêu Thân",Time = "04:22", Number = "5" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZB8DB8Z/320", NameMusic = "Em Như Nào Cũng Được",Time = "04:07", Number = "6" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/6BUDZUUW/320", NameMusic = "Bắt Cóc Con Tim",Time = "04:03", Number = "7" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/69IAOAFF/320", NameMusic = "Lời Anh Chưa Thể Nói",Time = "04:51", Number = "8" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/6BWZIB07/320", NameMusic = "Gác Lại Âu Lo",Time = "04:43", Number = "9" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/6BIFC9BI/320", NameMusic = "Phải chăng em đã yêu",Time = "03:10", Number = "10" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/6ACWB7ZI/320", NameMusic = "Chạy Về Khóc với anh",Time = "04:22", Number = "11" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/6ACWB7ZI/320", NameMusic = "Tình Yêu Ngủ Quên",Time = "02:54", Number = "12" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZDWA6AE/320", NameMusic = "Thiêu Thân",Time = "04:22", Number = "13" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZDWA6AE/320", NameMusic = "Thiêu Thân",Time = "04:22", Number = "14" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZDWA6AE/320", NameMusic = "Thiêu Thân",Time = "04:22", Number = "15" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZDWA6AE/320", NameMusic = "Thiêu Thân",Time = "04:22", Number = "16" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZDWA6AE/320", NameMusic = "Thiêu Thân",Time = "04:22", Number = "17" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZDWA6AE/320", NameMusic = "Thiêu Thân",Time = "04:22", Number = "18" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZDWA6AE/320", NameMusic = "Thiêu Thân",Time = "04:22", Number = "19" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZDWA6AE/320", NameMusic = "Thiêu Thân",Time = "04:22", Number = "20" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZDWA6AE/320", NameMusic = "Thiêu Thân",Time = "04:22", Number = "21" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZDWA6AE/320", NameMusic = "Thiêu Thân",Time = "04:22", Number = "22" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZDWA6AE/320", NameMusic = "Thiêu Thân",Time = "04:22", Number = "23" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZDWA6AE/320", NameMusic = "Thiêu Thân",Time = "04:22", Number = "24" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZDWA6AE/320", NameMusic = "Thiêu Thân",Time = "04:22", Number = "25" },
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZDWA6AE/320", NameMusic = "Thiêu Thân",Time = "04:22", Number = "26" },

                  //@"http://api.mp3.zing.vn/api/streaming/audio/6AC7IW0A/320",
                  //@"http://api.mp3.zing.vn/api/streaming/audio/ZZDA60O8/320",
                  //@"http://api.mp3.zing.vn/api/streaming/audio/ZZ98CW7W/320",
                  //@"http://api.mp3.zing.vn/api/streaming/audio/ZZDI9B7U/320",
                  //@"http://api.mp3.zing.vn/api/streaming/audio/ZZDWA6AE/320",//Thieu Than
            };
        }

        public ItemSong SelectedAudio
        {
            get => _selectedAudio;
            set
            {
                if (!Equals(_selectedAudio, value))
                {
                    _selectedAudio = value;
                    SourceMedia = value.LinkSong;
                    NotifyChanged("SourceMedia");
                }
            }
        }

        public ICommand NextCommand { get; set; }
        public ICommand PrevCommand { get; set; }

        private void NextCommandInvoke(object sender)
        {
            var indexOfCurrenSource = ListSounds.Select(x => x.LinkSong).ToList().IndexOf(SourceMedia);
            if (indexOfCurrenSource < ListSounds.Count - 1)
            {
                SourceMedia = ListSounds[indexOfCurrenSource + 1].LinkSong;
                NotifyChanged("SourceMedia");
            }
            else
            {
                SourceMedia = ListSounds[0].LinkSong;
            }
        }

        private void PrevCommandInvoke(object sender)
        {
            var indexOfCurrenSource = ListSounds.Select(x => x.LinkSong).ToList().IndexOf(SourceMedia);
            if (indexOfCurrenSource == 0)
            {
                SourceMedia = ListSounds[ListSounds.Count - 1].LinkSong;
                NotifyChanged("SourceMedia");
            }
            else
            {
                SourceMedia = ListSounds[indexOfCurrenSource - 1].LinkSong;
                NotifyChanged("SourceMedia");
            }
        }
    }
}