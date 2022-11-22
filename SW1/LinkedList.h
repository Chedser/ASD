#include <iostream>

/* ����� ������ */
template <typename T>
class LinkedList {

    /* ���� ������ */
    struct Node {
        T value; 	// �������� ����
        Node* next; // ��������� ������� ����

        Node(T value) : value(value), next(nullptr) {} // ����������� ����
    };

    Node* first; // ������ ������� ������
    Node* last; // ��������� ������� ������
    int count_of_elements = 0; // ���������� ��������� � ������
public:
    LinkedList() : first(nullptr), last(nullptr) {} // �����������
    ~LinkedList() // ����������
    {
        clear();
    }

    /* �������� �� ������� ������ */
    bool is_empty()
    {
        return first == nullptr;
    }

    /* �������� ������� � ������ */
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

    /* �������� �������� �� ������� */
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

    /* ������� ������ ������� */
    void remove_first()
    {
        if (is_empty()) return;
        Node* node = first;
        first = node->next;
        delete node;
        --count_of_elements;
    }

    /* ������� ��������� ������� */
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

    /* ���������� ��������� � ������ */
    int count() { return is_empty() ? 0 : count_of_elements + 1; }

    /* ������� ��� �������� � ������ */
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

    /* �������� ������� ������ �� ������� */
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

    /* ����������� ������ */
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
