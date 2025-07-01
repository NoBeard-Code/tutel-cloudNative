export function SetUpDaySelector(objRef)
{
    let dotNetObjRef = objRef;

    const platform = document.getElementById("platform");
    const VISIBLE_COUNT = 7;
    const CENTER_INDEX = Math.floor(VISIBLE_COUNT / 2);
    let selectedDate = new Date();

    let xTranslate = 0;

    const daysInPlatform = [];
    const handlers = [];

    function formatDate(date) {
        return date.toLocaleDateString(undefined, { weekday: 'short', day: 'numeric', month: 'short' });
    }

    function changeDayValues(centerDate) {
        const days = [];
        for (let i = -CENTER_INDEX; i <= CENTER_INDEX; i++) {
            const d = new Date(centerDate);
            d.setDate(centerDate.getDate() + i);
            days.push(d);
        }

        days.forEach((date, index) => {
            requestAnimationFrame(() => {
                daysInPlatform[index].offsetWidth;
                daysInPlatform[index].className = "daySelection-item" + (index === CENTER_INDEX ? " active" : "");
                daysInPlatform[index].offsetWidth;
            });
            daysInPlatform[index].textContent = formatDate(date);
            daysInPlatform[index].onclick = null;
            daysInPlatform[index].onclick = () => {
                selectedDate = date;
                changeDayValues(selectedDate);
                requestAnimationFrame(() => {
                    updateTransform(index);
                });
            };
        });
    }

    function generateDays(centerDate) {
        platform.innerHTML = "";
        const days = [];

        for (let i = -CENTER_INDEX; i <= CENTER_INDEX; i++) {
            const d = new Date(centerDate);
            d.setDate(centerDate.getDate() + i);
            days.push(d);
        }

        days.forEach((date, index) => {
            const div = document.createElement("div");
            requestAnimationFrame(() => {
                div.offsetWidth;
                div.className = "daySelection-item" + (index === CENTER_INDEX ? " active" : "");
                div.offsetWidth;
            });
            div.dataset.date = date.toISOString();
            div.textContent = formatDate(date);
            div.onclick = () => {
                selectedDate = date;
                generateDays(selectedDate);
                requestAnimationFrame(() => {
                    updateTransform(index);
                });
                const isoDate = div.dataset.date;
                dotNetObjRef.invokeMethodAsync("SelectDate", isoDate);
            };
            platform.appendChild(div);
            daysInPlatform.push(div);
        });

        requestAnimationFrame(() => {
            updateTransform();
        });
    }

    var firstClick = false;

    var previousTranslateX = 0;
    function updateTransform(index) {
        const container = document.getElementById("day-carousel");
        const items = document.querySelectorAll(".daySelection-item");
        if (!items.length) return;

        const itemWidth = items[0].offsetWidth;
        const containerWidth = container.offsetWidth;
        const offset = (CENTER_INDEX * itemWidth);
        const centerOffset = (containerWidth - itemWidth) / 2;

        if (index == undefined) {
            platform.style.transform = `translateX(${centerOffset - offset}px)`;
            return;
        }
        xTranslate = -(itemWidth * (index - CENTER_INDEX));
        if (index - CENTER_INDEX < 0) {
            platform.style.transform = `translateX(${-(offset - centerOffset) - xTranslate}px)`;
        }
        else {
            platform.style.transform = `translateX(${-(offset - centerOffset) - xTranslate}px)`;
        }
        items.forEach((item, index) => {
            //item.style.transform = `translateX(${xTranslate}px)`;
            item.style.setProperty("--extra-transform", `translateX(${xTranslate - 12}px)`);
        });
        previousTranslateX = xTranslate;
    }

    window.addEventListener("resize", updateTransform);

    generateDays(selectedDate);
};