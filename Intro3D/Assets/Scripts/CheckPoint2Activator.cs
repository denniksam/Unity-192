﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint2Activator : MonoBehaviour
{
    // Порожній ГО з колайдером, що має активувати CheckPoint2
    private void OnTriggerEnter(Collider other)
    {
        CheckPoint2.isActivated = true;
    }
}
/* Д.З. Прикласти посилання/архіви підсумкових проєктів.
 * 2D
 *  - Розміщення об'єктів, їх взаємодія як через колізії, так і 
 *     через тригери.
 *  - Фізика: взаємодія при зіткненнях (фізичні матеріали), гравітація
 *     (та відсутність гравітації) - рекомендовано включити до гри
 *     об'єкти, на які діє та на які не діє гравітація.
 *  - Рух: через прикладання сили/моменту сили або через трансляції/ротації
 *     за допомогою зміни позиції - рекомендовано включити об'єкти з
 *     різними способами руху (у т.ч. обертального руху)
 *  - Створення активація, деактивація та знищення елементів. Префаби.
 *     Рекомендовано забезпечити у грі різні способи управління ЖЦ елементів,
 *     у т.ч. з використанням префабів.
 *  - Відображення ігрової інформації - час гри, відомості про статус (енергію),
 *     накопичений рахунок.
 *  - Ігрове меню - забезпечити зупинку гри на час відображення меню (у т.ч. рух
 *     часу гри). Дублювати основну ігрову інформацію, додати елементи керування
 *     складністю, швидкістю гри тощо.
 *  - Збереження даних - на прикладі кращих результатів. Рекомендовано забезпечити
 *     ведення таблиці рекордів (щонайменше 3 позиції). У ігровому меню відображати
 *     таблицю, у разі потрапляння у перелік рекордів повідмоляти користувача.
 *     Бажано реалізувати підпис для фіксування рекорду, дозволяється 
 *     зазначати лише дату-час рекорду.
 *     
 * 3D
 *  - Те ж саме, що у 2D, а також
 *  - Керування камерою/камерами - рекомендовано забезпечити різні позиції камери,
 *     змінювати їх або плавно або перемиканням. Реалізувати обертання камери
 *  - Освітлення - рекомендовано розмістити у грі всі типи джерел світла, у т.ч.
 *     емісійні матеріали, а також текстуру неба
 *  - Звукове супроводження - фонова музика та звукові ефекти. Реалізувати
 *     керування включенням та гучністю музики та звуків, а також збереження
 *     налаштувань між запусками гри.
 *     
 *     
 */