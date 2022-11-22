
/*
package StudyWork3 – Листинг программы для 3-й лабораторной работы
* Вариант 2
*******************************************************************
* Имя файла : BinaryTree.java
* Резюме : Программа написанная на языке программирования Java
* Описание :  Дано бинарное дерево. 
* Найти в дереве длиннейший путь (пути), вдоль которого номера вершин упорядочены по возрастанию
* Автор : Морозов Олег группа 21-ИВТз-3
******************************************************************
*/

package StudyWork3;
import java.util.*;

public class BinaryTree {

	/* Класс узла */
	class Node
	{
	public
	    Node Right = null;
	    Node Left = null;
	    int Data;
	};

	Node Root = null; // Узел

	/* Вставка узла в дерево */
	void InsertNode(int Data)
	 {
	        Node DataNode = new Node();
	        DataNode.Data = Data;
	        DataNode.Left = DataNode.Right = null;

	        if (Root == null) {
	            Root = DataNode;
	            return;
	        }

	        Node tmpRoot = Root; 
	        Node prev = null;
	        while (tmpRoot != null)
	        {
	            prev = tmpRoot;
	            tmpRoot = (tmpRoot.Data < Data)?tmpRoot.Right:tmpRoot.Left;
	             
	            
	        }
	    
	        if(prev.Data < Data) {
	        	prev.Right = DataNode;
	        }else {
	        	prev.Left = DataNode;
	        }
	        
	    }

		/* Выбор узла с максимальным значением */
	    Vector MaxPath(Vector rightpath, Vector leftpath)
	    {
	        return (rightpath.size() > leftpath.size()) ? rightpath : leftpath;
	    }
	   
	    /* Обновление пути */
	    Vector UpdatePath(Node N, Vector v)
	    {
	        v.addElement(N.Data);
	        return   v;
	    }
	    
	    /* Получить максимальный путь */
	    Vector GetMaxLengthPath(Node root)
	    {
	        if (root == null) { return new Vector();}
	        return MaxPath(
	            UpdatePath(root, GetMaxLengthPath(root.Right)),
	            UpdatePath(root, GetMaxLengthPath(root.Left))
	            );
	    }

	    /* Получить максимальный путь */
	    Vector GetMaxLengthPath()
	    {
	        return GetMaxLengthPath(Root);
	    }
 
		
	 /* ГЛАВНАЯ ФУНКЦИЯ */
	  public static void main(String[] args) {
		 	BinaryTree binaryTree = new BinaryTree();

		    int nodes[] = { 11, 6, 8, 19, 4, 13, 5, 17, 43, 49, 16, 31, 32}; 		// Последовательность значений
		    int length =  nodes.length; 											// Длина последовательности

		    System.out.println("Исходные элементы");
		    
		    for(int i = 0; i < length; i++) {
		    	 System.out.println(nodes[i]);
		    }
		    
		    for (int i = 0; i < length; i++) { binaryTree.InsertNode(nodes[i]); } 	// Заполнение дерева

		    Vector maxPath = binaryTree.GetMaxLengthPath(); 						// Максимальный путь
		    		    
		    System.out.println("\nМаксимальная длина пути: " + maxPath.size() + "\n" );
		    System.out.println("Путь от корня до листа: ");
		
		    /* Печать максимального пути */
		    for (int i = (maxPath.size() - 1); i >= 0; i--)
		    {
		    	System.out.println(maxPath.get(i) + " ");

		    }
		    
		    System.out.println("\n");
		    
	    }
	  
}
