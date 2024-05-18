import { removeCookie } from "./api";

// Set authorization in local storage
export function setAuthorization(authResponse: any) {
  localStorage.setItem("accessToken", authResponse.jwtToken);
  localStorage.setItem("roles", authResponse.roles);
  localStorage.setItem("expires", new Date(authResponse.expires).toString());
}

// Check if there is time left on the token to se if it needs to be refreshed
export function checkTimeLeft() {
  const currentTime = new Date();
  const expires = new Date(localStorage.expires);

  return currentTime.getTime() >= expires.getTime();
}

// Logout function that removes the items from local storage and calls the removeCookie function to remove the cookie
export function logout() {
  localStorage.removeItem("accessToken");
  localStorage.removeItem("roles");
  localStorage.removeItem("expires");

  removeCookie();
}

// Get the access token from local storage
export function getAccessToken() {
  return localStorage.getItem("accessToken");
}

// Get the role from local storage
export function getRole() {
  return localStorage.getItem("roles");
}
