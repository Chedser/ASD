#include <iostream>

/* КЛАСС СПИСКА */
template <typename T>
class LinkedList {

    /* Узел списка */
    struct Node {
        T value; 	// Значение узла
        Node* next; // Следующий элемент узла

        Node(T value) : value(value), next(nullptr) {} // Конструктор узла
    };

    Node* first; // Первый элемент списка
    Node* last; // Последний элемент списка
    int count_of_elements = 0; // Количество элементов в списке
public:
    LinkedList() : first(nullptr), last(nullptr) {} // Конструктор
    ~LinkedList() // Деструктор
    {
        clear();
    }

    /* Проверка на пустоту списка */
    bool is_empty()
    {
        return first == nullptr;
    }

    /* Добавить элемент в список */
    void push(T value)
    {
        Node* node = new Node(value);
        if (is_empty()) 
        {
            first = node;
            last = node;
            return;
        }
        last->next = node;
        last = node;
        ++count_of_elements;
    }

    /* Получить значение по индексу */
    T get_by_index(const int index)
    {
        if (is_empty()) throw 1;
        Node* node = first;
        for (int i = 0; i < index; i++) 
        {
            node = node->next;
            if (!node) throw 1;
        }
        return node->value;
    }

    /* Удалить первый элемент */
    void remove_first()
    {
        if (is_empty()) return;
        Node* node = first;
        first = node->next;
        delete node;
        --count_of_elements;
    }

    /* Удалить последний элемент */
    void remove_last()
    {
        if (is_empty()) return;
        if (first == last) 
        {
            remove_first();
            return;
        }
        Node* node = first;
        while (node->next != last) node = node->next;
        node->next = nullptr;
        delete last;
        last = node;
        --count_of_elements;
    }

    /* Количество элементов в списке */
    int count() { return is_empty() ? 0 : count_of_elements + 1; }

    /* Удалить все элементы в списке */
    void clear()
    {
        if (is_empty()) return;
        if (first == last) 
        {
            remove_first();
            return;
        }

        Node* tmpNode;
        while (last) 
        {
            tmpNode = last;
            last = tmpNode->next;
            delete tmpNode;
        }

        count_of_elements = 0;
        first = nullptr;
        last = nullptr;
    }

    /* Заменить элемент списка по индексу */
    void replace(int index, T to)
    {
        if (is_empty()) throw 1;
        Node* node = first;
        for (int i = 0; i < index; i++) 
        {
            node = node->next;
            if (!node) throw 1;
        }

        node->value = to;

    }

    /* Распечатать список */
    void print()
    {
        if (is_empty()) return;
        Node* node = first;
        while (node) 
        {
            std::cout << node->value << std::endl;
            node = node->next;
        }
        std::cout << std::endl;
    }

};
