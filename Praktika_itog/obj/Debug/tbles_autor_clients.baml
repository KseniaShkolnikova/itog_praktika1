   M S B A M L   `   `   `  ����H  DPraktika_itog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Praktika_itogPraktika_itog  5      '    !Praktika_itog.tbles_autor_clients   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Praktika_itog     5        N� Title$  tbles_autor_clients��5	      .��5      � ���	#FFF0C9ED � ColumnDefinitions 5   
   �� 5      $
��221* �6   �� 5      $
��579* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ gridik��5         AutoGenerateColumns .  $��1��6?      
IsReadOnly . ���	#FFEEDDED   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Логин *��6A   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Logini+6A     5      $ Пароль *��6@    6%   �� *Porol+6@     5      $# Фамилия клиента��6J    6%   �� *Clients.Surname+6J   5      � 5   
   $��0��6    � RowDefinitions 5      �� 5      $	��62* �6    �� 5      $	��62* �6    �� 5      $	��62* �6    �� 5      $	��52* �6    �� 5      $	��67* �6    �� 5      $	��52* �6    �� 5      $	��67* �6    �� 5       $	��67* �6    �� 5!      $	��67* �6    .+�5#      �� -   5        $��delete��5#   '   $��Удалить��6   $��0��65   ���	#FFAAE9FD$��5q�6Y   6d   �� 5$      -   5        $��dobav��5$   (   $��Добавить��6   $��1��65   ���	#FFAAE9FD$��5q�6Y   6d   �� 5%      -   5        $��izmen��5%   (   $��Изменить��6   $��2��65   ���	#FFAAE9FD$��5q�6Y   6d   �� 5&      $��Center=�6   $��3��66   $
��Wrap=�6C   $��Логин *��6W   $��Center=�6f   �� 5'      $��Center=�6   $��5��65   $
��Wrap=�6B   $��Пароль *��6V   $��Center=�6f   �� 5(      $��Center=�6   $��7��65   $
��Wrap=�6B   $%��Фамилия клиента *��6V   $��Center=�6o   �� 5)      -   5        	 ��Name$	 text1��5)      $��4��6%   
 �� TextWrapping$

 Wrap=�62   $
��5,10q�6G   �� 5*      -   5        $��text2��5*   $   $��6��6   $

 Wrap=�61   $
��5,10q�6F   �� 5+      -   5        $��combobox��5+       �� DisplayMemberPath$ Surname��6'   $��8q�6C   $��8��6N   5-      5.      5/      