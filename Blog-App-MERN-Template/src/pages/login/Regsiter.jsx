import React, { useState, useEffect } from "react";
import "./login.css"
import back from "../../assets/images/my-account.jpg"
import axios from "axios";

export const Regsiter = () => {

  const [formData, setFormData] = useState({
    firstName: "",
    lastName: "",
    email: "",
    password: "",
  });
  const [registrationSuccess, setRegistrationSuccess] = useState(false); // State to control the popup

  // Function to handle form input changes
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  // Function to handle form submission
  const handleFormSubmit = async (e) => {
    e.preventDefault();

    try {
      // Make a POST request to your API to register the user
      const response = await axios.post("https://localhost:7029/api/Register", formData);
      // Handle the response, e.g., show a success message
      console.log("Registration successful", response.data);
      setRegistrationSuccess(true); 
      // Clear the form after successful registration
      setFormData({
        firstName: "",
        lastName: "",
        email: "",
        password: "",
      });
      setTimeout(() => {
        setRegistrationSuccess(false);
      }, 3000);
    } catch (error) {
      // Handle errors, e.g., display an error message
      console.error("Registration failed", error);
    }
  };
  useEffect(() => {
    // Cleanup: Clear the timeout if the component unmounts before the timeout finishes
    let timer;
    if (registrationSuccess) {
      timer = setTimeout(() => {
        setRegistrationSuccess(false);
      }, 3000);
    }
    return () => clearTimeout(timer);
  }, [registrationSuccess]);
  
  const closePopup = () => {
    setRegistrationSuccess(false); // Close the success popup
  };
  return (
    <>
      <section className="login">
        <div className="container">
          <div className="backImg">
            <img src={back} alt="" />
            <div className="text">
              <h3>Register</h3>
              <h1>My account</h1>
            </div>
          </div>

          <form onSubmit={handleFormSubmit}>
            <span>First Name *</span>
            <input
              type="text"
              name="firstName"
              value={formData.firstName}
              onChange={handleInputChange}
              required
            />
            <span>Last Name *</span>
            <input
              type="text"
              name="lastName"
              value={formData.lastName}
              onChange={handleInputChange}
              required
            />
            <span>Email *</span>
            <input
              type="email"
              name="email"
              value={formData.email}
              onChange={handleInputChange}
              required
            />
            <span>Password *</span>
            <input
              type="password"
              name="password"
              value={formData.password}
              onChange={handleInputChange}
              required
            />
            <button type="submit" className="button">
              Register
            </button>
          </form>
        </div>
      </section>
      {registrationSuccess && (
        <div className="popup">
          <div className="popup-content">
            <span className="close" onClick={closePopup}>
              &times;
            </span>
            <p>Registration successful!</p>
          </div>
        </div>
      )}
    </>
  );
};