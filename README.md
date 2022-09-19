# ВИРТУАЛЬНАЯ И ДОПОЛНЕННАЯ РЕАЛЬНОСТЬ
## Лабораторная работа №1. Основы работы с Unity
Отчет по лабораторной работе №1 выполнил(а):
- Дмитриев Виталий Денисович
- РИ-300014

Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | * | 20 |
| Задание 3 | * | 20 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

Работу проверили:
- к.т.н., доцент Денисов Д.В.
- к.э.н., доцент Панов М.А.
- ст. преп., Фадеев В.О.

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Структура отчета

- Данные о работе: название работы, фио, группа, выполненные задания.
- Цель работы.
- Задание 1.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 2.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 3.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Выводы.
- ✨Magic ✨

## Цель работы
Ознакомиться с основными функциями Unity и взаимодействием с объектами внутри редактора.

## Задание 1
### Пошагово выполнить каждый пункт раздела "ход работы" с описанием и примерами реализации задач по теме лабораторной работы.
Ход работы:
1. Создать новый проект из шаблона 3D-Core.

![](Screenshots/1.png)

2. Проверить, что настроена интеграция редактора Unity и Visual Studio Code.

Изначально вместо Visual Studio Code был интегрирован Visual Studio 2022, поэтому дальнейшая работа будет осуществляться в нём.
Был создан и открыт новый скрипт. Интеграция настроена успешно. Результат показан на скриншоте ниже:

![](Screenshots/2.png)

3. Создать объект `Plane`;

Был создан объект Plane через пункт 3D Object контекстного меню окна Hierarchy:

![](Screenshots/3.png)

4. Создать объект `Cube`;

![](Screenshots/4.png)

5. Создать объект `Sphere`;

![](Screenshots/5.png)

6. Установить компонент `Sphere Collider` для объекта Sphere;

При создании объекта `Sphere` компонент `Sphere Collider` сразу добавляется на него сам.

![](Screenshots/6.png)

7. Настроить `Sphere Collider` в роли триггера;

Установили галочку в поле `Is Trigger` компонента `Sphere Collider` в окне Inspector:

![](Screenshots/7.png)

8. Объект куб перекрасить в красный цвет;

Сначала был создан новый материал:

![](Screenshots/8.png)

Затем в окне Inspector был изменён цвет материала на красный:

![](Screenshots/9.png)

После этого материал был добавлен объекту `Sphere`:

![](Screenshots/10.png)

9. Добавить кубу симуляцию физики, при этом куб не должен проваливаться под `Plane`;

На куб был добавлен компонент `RigitBody`, а также, чтобы куб не падал и оставался на месте, была убарана галочка в поле `UseGravity` и установлена галочка в поле `Is Kinematic`:

![](Screenshots/11.png)

10. Написать скрипт, который будет выводить в консоль сообщение о том, что объект Sphere столкнулся с объектом Cube;

Был создан скрипт `CheckCollider` со следующим кодом:

```cs
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Произошло столкновение с " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Завершено столкновение с " + other.gameObject.name);
    }
}
```

Методы `OnTriggerEnter` и `OnTriggerExit` срабатывают, когда объект сталкивается с другим объектом и уходит из области столкновения с ним соответственно.
Скрипт `CheckCollider` был добавлен объекту Sphere, после чего был запущен проект.
Вывод в консоль после столкновения `Sphere` с `Cube`:

![](Screenshots/12.png)

Вывод в консоль в момент, когда Sphere уходит из области столкновения:

![](Screenshots/13.png)

11. При столкновении Cube должен менять свой цвет на зелёный, а при завершения столкновения обратно на красный.

В скрипте `CheckCollider` в методы `OnTriggerEnter` и `OnTriggerExit` были добавлены строки, изменяющие цвет материала объект, с которым столкнулся `Sphere`:

```cs
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Произошло столкновение с " + other.gameObject.name);
        other.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Завершено столкновение с " + other.gameObject.name);
        other.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
}
```

После чего запустили проект.
В процессе столкновения:

![](Screenshots/14.png)

После столкновения:

![](Screenshots/15.png)

## Задание 2
### Продемонстрируйте на сцене в Unity следующее:

- Что произойдёт с координатами объекта, если он перестанет быть дочерним?

Пусть куб имеет координаты (2, 2, 2). Пусть сфера имеет те же самые координаты, таким образом, сфера будет находиться в кубе:

![](Screenshots/16.png)

Сферу сделали дочерним к кубу объектом. Координаты сферы изменились на (0, 0, 0). Таким образом, начало координат для сферы сместилось в центр куба. Позиция любых дочерних объектов в редакторе Unity рассматриваются относительно позиции их родительских объектов. В таком случае мы говорим о локальных координатах.

![](Screenshots/17.png)

Если сфера перестанет быть дочерним к кубу, то её координаты изменятся обратно на (2, 2, 2). Так, все объекты, не имеющих родителя, позиционируются относительно мировой системы координат, зафиксированной в сцене. В таком случае мы говорим о глобальных координатах.

- Создайте три различных примера работы компонента RigitBody?

Свойство `Is Kinematic` может быть включено, если требуется, чтобы объект оставался твёрдым телом, но не подвергался влиянию физики. При этом он по-прежнему влияет на другие физические тела посредством столкновений. В примере у куба установлено свойство `Is Kinematic`, и шар, падая вниз, сталкивается с кубом и скатывается с него на платформу. Куб при этом остаётся неподвижным. В любой момент свойство Is Kinematic может быть отключено, чтобы объект объект мог подвергаться влиянию физики. Это полезно, когда обычно объект управляется анимацией, но иногда требуется делать его так называемой "тряпичной куклой".

![](Screenshots/18.png)

Масса объектов может быть изменена. В примере массу сферы установили на 10, а массу куба на 1. Таким образом, если сфера будет двигаться в сторону куба, то она с лёгкостью будет толкать куб. А куб, в свою очередь, будет толкать сферу с большим трудом. Это можно использовать, например, чтобы задать разным предметам мебели разную массу, чтобы такие большие предметы мебели, как шкаф или кровать, можно было двигать с большим трудом, а, например, стул или торшер - прикладывая минимум усилий.

![](Screenshots/19.png)

У объектов можно отключить гравитацию. В примере левый шар имеет гравитацию и сталкивается с правым шаром, у которого гравитация отсутствует. В результате чего шар с гравитацией падает вниз на платформу, а шар без гравитации немного отлетает в сторону и останавливается в воздухе. Это можно использовать для симуляции физики некоторых объектов в космосе или под водой.

В момент столкновения:

![](Screenshots/20.png)

После столкновения:

![](Screenshots/21.png)

## Задание 3
### Реализуйте на сцене генерацию n кубиков. Число n вводится пользователем после старта сцены.

Был создан UI-элемент `Input Field`, чтобы пользователь мог вводить количество кубиков после старта сцены:

![](Screenshots/22.png)

Создали скрипт `CubeGenerator` со следующим кодом:

```cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private Transform spawnPoint;

    public void Generate()
    {
        var text = GetComponent<TMP_InputField>().text;
        if (text == "")
            return;

        var count = int.Parse(text);
        for (var i = 0; i < count; ++i)
            Instantiate(cube, spawnPoint.position, Quaternion.identity);
    }
}
```

Скрипт был добавлен объекту `Input Field`. Сделали красный куб префабом, который впоследствии перетащили в поле Cube в скрипте. Кроме того, была установлена точка появления кубов. Результат работы приведён на скриншоте ниже:

![](Screenshots/23.png)

## Выводы

Таким образом, в результате лабораторной работы были получены необходимые навыки и знания по основам работы в редакторе Unity, а также по работе с компонентом симуляции физики `RigitBody`. Были рассмотрены различные варианты взаимодействия объектов, позиционирование объектов в зависимости от их расположения в иерархии, а также принцип работы скриптов и их использование в редакторе Unity.

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
