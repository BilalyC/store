   M S B A M L   `   `   `  ����@  <store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:magasinmagasin  5          magasin.stockGestion   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:magasin     5      -   5          N� Title$  stockGestion��5	      .��5      � ���	#FF0C090D$��-2,0,2,0q�6"   .+�5   
   ]� $	��600��6   $��0,0,0,0q�6!   .+�5      �� .+�5      �� $��70��6   $��28(�6(   $
��Bold"�66    �� TextAlignment$ Center=�6H   $6��0/store;component/theodora/#Theodora Personal Use)�6_   
�������Gestion des Stocks6�   &   System.Windows.Controls.DataGrid  5      -   5        $��Products��5         AutoGenerateColumns .  $	��700��6_   ��6+   �� ��5      �� 5       �� ImageSource$? 9C:\Users\Moi\source\wpf\store\store\assets\image\bac2.jpg��6%    j� Stretch$ UniformToFill=�6m      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Image��61      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6S   	   CellTemplate	 5      �� 5   "   .R�5   &   �� $��50��6E   ��6,   �� *image+6E   5   #   5      0  *System.Windows.Controls.DataGridTextColumn  5      $	 Nom��6-   $ * 6S   
   
FontFamily$J
 D/store;component/antonellie_calligraphy/#Antonellie Calligraphy Demo)�6]   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *name+6]     5      $ Description��6-   $ * 6b   $J
 D/store;component/antonellie_calligraphy/#Antonellie Calligraphy Demo)�6l    6B   �� *description+6l     5      $ 	Reference��6-   $ * 6^   $J
 D/store;component/antonellie_calligraphy/#Antonellie Calligraphy Demo)�6h    6@   �� *	reference+6h     5      $
 Prix��6-   $ * 6U   $J
 D/store;component/antonellie_calligraphy/#Antonellie Calligraphy Demo)�6_    6;   �� *price+6_     5      $ Quantité en stock��6-   $ * 6e   $J
 D/store;component/antonellie_calligraphy/#Antonellie Calligraphy Demo)�6o    6H   �� *
quantity+6o   5!      5"      �� 5#      $	��295��6   $	��600��6%   ��5$      �� 5%       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5&      �  � Color$ Black��6'    � Offset$ 0.078Q�65   � 5'      $ 	#FFFF0202��6'   $ 0.651Q�69   5(      .+�5*      �� $��Center=�6   $��20(�69   $
��Bold"�6H   $��0,0,0,0q�6Z   
�������$��Nyala)�6~   Votre Produit6�   �� 5+      $��2q�6   
�������._�5,      �� -   5         ��Name$ image��5,   N   $	��140��6   $	��230��6)   $
��10,0q�6]   ��65   �� *image+6]   5-      �� 5.      
�������$��22(�6,   $
��Bold"�6:   $��Nyala)�6L   .��6`   Nom :6g   �� 5/      -   5         ��Name$ nameProduct��5/   9   $��25��6   
�������$
��10,0q�6N   6^   �� 50      
�������$��22(�6,   $
��Bold"�6:   $��Nyala)�6L   .��6_   Description :6n   �� 51      -   5         ��Name$ DescProduct��51   ;   $��25��6   
�������$
��10,0q�6P   6`   �� 52      
�������$��22(�6,   $
��Bold"�6:   $��Nyala)�6L   .��6_   Reference :6l   �� 53      -   5        $ 
refProduct��53   ;   $��25��6   
�������$
��10,0q�6O   6_   �� 54      
�������$��22(�6,   $
��Bold"�6:   $��Nyala)�6L   .��6_   Catégorie :6l   �� 55      -   5        $��
Categories��55   '   $��25��6   $
��10,0q�6e   ��56      �� 57      .R�58      ��  �� Orientation$ 
Horizontal=�6)   .+�59   "   �� ��6,   �� *name+5:      5;      5=      �� 5>      
�������$��22(�6,   $
��Bold"�6:   $��Nyala)�6L   .��6_   Prix :6g   �� 5?      -   5        $ priceProduct��5?   9   $��25��6   
�������$
��10,0q�6O   6_   �� 5@      
�������$��22(�6-   $
��Bold"�6;   $��Nyala)�6M   .��6`   	Stock :6i   �� 5A      -	   5        $ stockProduct��5A   9   $��25��6   
�������$
��10,0q�6O   6_   ]� 5C      $	��290��6   $��0,10,0,0q�6)   $��60��6;   .+�5D      �� -
   5        
���iii�$
��Bold"�5D   2   
�������$	��150��6W   $��50��6c   $��0,0,0,0q�6o   $6��0/store;component/theodora/#Theodora Personal Use)�6�   $��17(�6�   .��6�   Retirer Article6�   �� 5E      -   5        
��� � �$
��Bold"�5E   0   
�������$	��130��6U   $��50��6b   $��0,0,0,0q�6n   $��Right=�6   $6��0/store;component/theodora/#Theodora Personal Use)�6�   $��22(�6�   .��6�   
Modifier6  5F      5G      5I      5J      5K      