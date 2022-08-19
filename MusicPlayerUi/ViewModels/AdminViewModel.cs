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
                new ItemSong(){LinkSong = @"http://api.mp3.zing.vn/api/streaming/audio/ZZDWA6AE/320", NameMusic = "Thiêu Thân",Time = "04:22", Number = "4" },

                  //@"http://api.mp3.zing.vn/api/streaming/audio/ZZCZCCED/320",
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