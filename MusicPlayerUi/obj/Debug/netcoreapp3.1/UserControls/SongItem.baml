   M S B A M L   `   `   `  ����  MusicPlayer'    !MusicPlayer.UserControls.SongItem   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $��songItem��5      .��5      �� $��0 0 0 3q�6     �� CornerRadius$  5��6    �� Padding$ 7q�6/   ��5   
   �� 5	       �� 
TargetType" ��6    �� Triggers 5
      P� 5       P� Property �@J�IsMouseOver P� Value$
 True��65   . �5      ��  �� Property � �� �� Value �#1aab7a67   5      �� 5       �� Binding 6"   �� 	 �� ElementName$	 songItem��
 �� Path$
 IsActive� �� Value True6Y   .a�5      ��  � �� �#1aab7a67   5      5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $	��200 �6#   �� 5      $��* �6#   .+�5      �� ���#c2e8dc$��16(�6`   $��SemiBold"�6n   $��5 0 30 0q�6�   ��6   �� $	 songItem��$
 Number�6�   �� 5      $��1��6K   
�������$��16(�6n   $��SemiBold"�6|   $��0 0 0 2q�6�   ��6   �� $	 songItem��$
 Title�6�   �� 5      $��2��6I   ���#c2e8dc$��16(�6n   $��SemiBold"�6|   $��0 0 5 2q�6�   $��Right=�6�   ��6   �� $	 songItem��$

 Time�6�   5      5       5!      