   M S B A M L   `   `   `  ����H  DPraktika_itog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Praktika_itogPraktika_itog  5   	        Praktika_itog.clients_main   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Praktika_itog     5   	     � Title$  clients_main��5   	   $	��450��6   $	��800��6+   .��5	      � ���	#FFEEDDED � RowDefinitions 5
   
   �� 5      $
��153* �6   �� 5      $	��40* �6   �� 5      $	��24* �6    � ColumnDefinitions 5   
   �� 5      $
��100* �6   �� 5      $	��20* �6   �� 5      $
��100* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ gridik��5      $��10,10,10,10q�6#   $��0��68      AutoGenerateColumns .  $��0��6d      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Name_Of_Good+6G     5      $ цена��6E    6%   �� *
Good_Price+6E     5      $ Тип��6X    6%   �� *Goods_Types.Name_Of_Good_Type+6X   5        5   
   -   5        $ gridik2��5      $��10,10,10,10q�6$    .  $��0��6U   $��2��6b    .  5        5      $ Название��6I    6%   �� *Name_of_product+6I     5      $ цена��6?    6%   �� *Price+6?   5       � 5!   
   $��0��6   $��1��6    5"      �� 5#      �� 5$      .+�5&      �� -   5        $��Добавить��5&      $��0��6(   $��0,0,0,10q�65   $��Bottom=�6G   ���	#FFAAE9FD6z   �� 5'      -   5        $��Убрать��5'      $��1��6&   $��0,10,0,0q�63   $	��Top=�6E   ���	#FFAAE9FD6r   5(      �� 5)   
   -   5        $��zakaz��5)   )   $��Сделать заказ��6   $��2��66   $��2��6C   $��10,10,10,10q�6S   ���	#FFAAE9FD6|   �� 5*   
   -   5        $��vixod��5*   !   $��
Выйти��6   $��2��6.   $��0��6;   $��10,10,10,10q�6K   ���	#FFAAE9FD6t   � 5+   
   $��0��6   $��2��6   $��0,3,72,0q�63   $��1��6E    5,      �� 5-      $	��89* �6#   �� 5.      $
��275* �6#   .+�50      �� $
��Left=�6   $��	10,10,0,0q�63   $��0��6F   $
��Wrap=�6V   $2��,Выберите способ оплаты *��6j   $	��Top=�6�   �� 51      -   5        $��combobox��51   3   $��10q�6   $��1��6#   	 �� DisplayMemberPath$	 Name_Of_Payment_Type��6C   52      � 53   
   $��1��6   $��2��6   $��72,3,0,0q�63   $��1��6E    54      �� 55      �� 56      .+�58      �� -   5        $��	textblock��58      $��0��6)   $
��Wrap=�67   �� 59      -	   5        $��textbox��59   #   $��1��6   
 �� TextWrapping$

 Wrap=�62   5;      5<      5=      