// contact.js
document.addEventListener('DOMContentLoaded', function () {
    emailjs.init("ph0xpDeI3pUmYLAn6");

    document.getElementById('contactForm').addEventListener('submit', function (event) {
        event.preventDefault();

        const statusMsg = document.getElementById('statusMessage');

        emailjs.send("service_paiqvxq", "template_xrtvqar", {
            user_name: document.getElementById('name').value,
            user_email: document.getElementById('email').value,
            subject: document.getElementById('subject').value,
            message: document.getElementById('message').value,
            time: new Date().toLocaleString()
        })

            .then(function (response) {
                statusMsg.textContent = "Message envoyé avec succès !";
                statusMsg.style.color = "green";
                document.getElementById('contactForm').reset();
            }, function (error) {
                statusMsg.textContent = "Erreur lors de l'envoi. Réessayez plus tard.";
                statusMsg.style.color = "red";
            });
    });
});
