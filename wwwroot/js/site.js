//Access to reservation managment
let manage_reseravtions = document.querySelector('.manage-reseravtions');


const checkAdmin = event => {
    event.preventDefault();
    let answer = prompt('Enter an admin password to manage reservations:');
    //Password: 1111
    if (answer == '1111') {
        location.href = '/Reservation/Index';
    } else {
        alert('Sorry, password is wrong!');
    }
}


manage_reseravtions.addEventListener('click', checkAdmin);

document.querySelectorAll('.hasDatepicker').forEach(el => {
    el.addEventListener('input', () => {
        el.value = `${el.value} 00:00:00`;
        console.log(el.value);
    })
})
//FormData
