   M S B A M L   `   `   `  ����H  DPraktika_itog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Praktika_itogPraktika_itog  5          Praktika_itog.table_check   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Praktika_itog     5        N� Title$  table_check��5	      .��5
      � ���	#FFF0C9ED � ColumnDefinitions 5   
   �� 5      $	��82* �6   �� 5      $
��171* �6   �� 5      $
��547* �6    � RowDefinitions 5   
   �� 5      $	��67* �6   �� 5      $	��67* �6   �� 5      $	��67* �6   �� 5      $	��62* �6   �� 5      $	��62* �6   �� 5      $	��62* �6   �� 5      $	��62* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ gridik��5         AutoGenerateColumns .  $��2��6?   $��0��6O   $��7��6\      
IsReadOnly . ���	#FFEEDDED   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$# Название товара��6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Goods.Name_Of_Good+6M     5      $ Номер заказа��6C    6%   �� *
Order_ID+6C     5      $) #Фамилия сотрудника��6L    6%   �� *Employees.Surname+6L     5      $ Дата покупки��6J    6%   �� *Date_Of_Payment+6J     5      $ 
Сумма��6?    6%   �� *Summ+6?   5!      �� 5"   
   -   5        $��delete��5"   G   $��Удалить��6   $��0��6#   $��2��63   $��0��6U   $��5,5,5,5q�6b   ���	#FFAAE9FD6�   �� 5#   
   -   5        $��dobav��5#   H   $��Добавить��6   $��0��6$   $��2��64   $��1��6U   $��5,5,5,5q�6b   ���	#FFAAE9FD6�   �� 5$   
   -   5        $��izmen��5$   H   $��Изменить��6   $��0��6$   $��2��64   $��2��6U   $��5,5,5,5q�6b   ���	#FFAAE9FD6�   �� 5%   
   -   5        $��	combobox3��5%      $��1��6$   $��3��64   $��5q�6A   	 �� DisplayMemberPath$	 ID_Order��6L   �� 5&   
   -   5        $��	combobox4��5&      $��1��6$   $��4��64   $��5q�6A   $	 Surname��6L   �� 5'   
   -   5        $��	combobox5��5'      $��1��6$   $��5��64   $��5q�6A   $	 Name_Of_Good��6L   �� 5(   
   $��3��6   $��Center=�6!   $
��Wrap=�6>   $��Номер заказа *��6R   $��Center=�6h   $��16��6�   $��64��6�   �� 5)   
   $��4��6   $��Center=�6!   $
��Wrap=�6>   $+��%Фамилия сотрудника *��6R   $��Center=�6n   $��16��6�   $��64��6�   �� 5*   
   $��5��6   $��Center=�6!   $
��Wrap=�6>   $��Товар *��6R   $��Center=�6a   $��16��6|   $��64��6�   �� 5+   
   $��6��6   $��Center=�6!   $
��Wrap=�6>   $��Дата заказа *��6R   $��Center=�6g   (  "System.Windows.Controls.DatePicker  5,   
   -   5        $��datapick��5,      $��6��6%   $��1��63   $��Center=�6C   
   FirstDayOfWeek$
 Monday=�6^      DisplayDateStart$ 
2024-03-10X�6v      DisplayDateEnd$ 
2024-04-27X�6�   $��24��6�   5-      5.      