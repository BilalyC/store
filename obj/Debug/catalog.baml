   M S B A M L   `   `   `  ����@  <store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:magasinmagasin  5          magasin.catalog   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:magasin     5        N� Title$  catalog��5	      .��5      � ���#f40000.+�5   
   �� .+�5      o� $��30��6   $��0,0,0,0q�6   
���   �.@�5      m� $��Categorie de musique��6   $��32��69   ���	#FF080808$
��Bold"�6]   $��Center=�6o   
���W�.�$��
0,-1,0,-30q�6�   
�������$��3q�6�   .@�5      m� -   5         m�Name$	 all��5   @   $
��Tous��6   
���   �6M   m� 5      -   5        $
 jazz��5   @   $
��Jazz��6   
���   �6N   m� 5      -   5        $
 rock��5   @   $
��Rock��6   
���   �6N   m� 5      -   5        $ 	classique��5   E   $��	Classique��6   
���   �6X   m� 5      -   5        $ electro��5   C   $��Electro��6   
���   �6T   m� 5      -   5        $	 rap��5   ?   $	��Rap��6   
���   �6L   5      5      ]� 5      $	��573��6   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ Black��6'    � Offset$ 0Q�65   � 5      $ 	#FFDC0909��6'   $ 1Q�69   5      .+�5      &   System.Windows.Controls.DataGrid  -   5        $��products��5         AutoGenerateColumns .  $	��700��6_   ��6+   �� ��5      �� 5       $ 0.5,1&�6.   $ 0.5,0&�6?   .��5!      � $ Black��6+   $ 0Q�69   � 5"      $ White��6+   $ 1Q�69   5#         Columns 5%      4  .System.Windows.Controls.DataGridTemplateColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$ Image��61   	   
IsReadOnly	 . 
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6S      CellTemplate 5'      �� 5(   "   .R�5)   &   �� $��50��6E   ��6,   �� *image+6E   5*   #   5,      0  *System.Windows.Controls.DataGridTextColumn  5-      $	 Nom��6-   $
 * 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *name+6S     5.      $ Description��6-   $
 * 6b    6B   �� *description+6b     5/      $ 	Reference��6-   $
 * 6^    6@   �� *	reference+6^     50      $
 Prix��6-   $
 * 6U    6;   �� *price+6U     51      $ Quantité en stock��6-   $
 * 6e    6H   �� *
quantity+6e   53      �� 54      $	��280��6   ��55      �� 56      $ 0.5,1&�6.   $ 0.5,0&�6?   .��57      � $ Black��6+   $ 0Q�69   � 58      $ 	#FFD61313��6+   $ 1Q�6=   59      .+�5;      �� $��Center=�6    $��36(�6=   
�������$��Ballet Harmony)�6^   Votre Produit6�   �� 5<      -   5         ��Name$ image��5<   5   $	��200��6   $	��280��6)   ��6D   �� *image+�� 5=      .��6   Nom6!   �� 5>      -	   5         ��Name$ nameProduct��5>   ?   $��25��6    
�������6V   �� 5?      .��6   Description6)   �� 5@      -
   5        $ descProduct��5@   ?   $��25��6    
�������6V   �� 5A      .��6   	Reference6'   �� 5B      -   5        $ 
refProduct��5B   ?   $��25��6    
�������6U   �� 5C      .��6   Prix6"   �� 5D      -   5        $ priceProduct��5D   ?   $��25��6    
�������6W   �� 5E      .��6   Stock6#   �� 5F      -   5        $ stockProduct��5F   ?   $��25��6    
�������6W   5G      5H      5I      5J      5K      