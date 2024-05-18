import { getAccessToken } from "./auth";

const API_URL = "https://localhost:7280/api/";

const ENDPOINTS = {
  REFRESHTOKEN: `${API_URL}Auth/RefreshToken`,
  LOGIN: `${API_URL}Auth/Login`,
  LOGOUT: `${API_URL}Auth/Logout`,
  BADGEGROUPS: `${API_URL}Badgegroups/`,
};

const jsonHeaders = {
  "Content-Type": "application/json",
};

// login function that sends a POST request to the server and returns the response
export async function login(username: string, password: string): Promise<any> {
  const response = await fetch(ENDPOINTS.LOGIN, {
    method: "POST",
    headers: {
      ...jsonHeaders,
    },
    body: JSON.stringify({ username, password }),
    credentials: "include",
  });

  if (!response.ok) {
    throw new Error("Login failed");
  }
  return response.json();
}

// refreshTokens function that sends a POST request to the server and returns the response
export async function refreshTokens(): Promise<any> {
  const response = await fetch(ENDPOINTS.REFRESHTOKEN, {
    method: "POST",
    headers: {
      ...jsonHeaders,
      Authorization: "Bearer " + getAccessToken(),
    },
    credentials: "include",
  });

  if (!response.ok) {
    throw new Error("Error refreshing token");
  }

  return response;
}

// removeCookie function that sends a POST request to the server
export async function removeCookie(): Promise<any> {
  await fetch(ENDPOINTS.LOGOUT, {
    method: "POST",
    headers: {
      ...jsonHeaders,
    },
    credentials: "include",
  });
}

// getBadgegroups function that sends a GET request to the server and returns the response
export async function getBadgegroups(): Promise<any> {
  const response = await fetch(ENDPOINTS.BADGEGROUPS, {
    method: "GET",
    headers: {
      ...jsonHeaders,
      Authorization: "Bearer " + getAccessToken(),
    },
    credentials: "include",
  });

  if (!response.ok) {
    throw new Error("Error fetching badgegroups");
  }

  return response.json();
}

// getBadgegroup function that sends a GET request to the server and returns the response
export async function getBadgegroup(badgegroupId: string): Promise<any> {
  const response = await fetch(ENDPOINTS.BADGEGROUPS + badgegroupId, {
    method: "GET",
    headers: {
      ...jsonHeaders,
      Authorization: "Bearer " + getAccessToken(),
    },
    credentials: "include",
  });

  if (!response.ok) {
    throw new Error("Error fetching badgegroup");
  }
  return response.json();
}

// createBadgegroup function that sends a POST request to the server
export async function createBadgegroup(name: string): Promise<any> {
  const response = await fetch(ENDPOINTS.BADGEGROUPS, {
    method: "POST",
    headers: {
      ...jsonHeaders,
      Authorization: "Bearer " + getAccessToken(),
    },
    body: JSON.stringify({ name }),
    credentials: "include",
  });

  if (!response.ok) {
    throw new Error("Error creating badgegroup");
  }
}

// getStudentsInBadgegroup function that sends a GET request to the server and returns the response
export async function getStudentsInBadgegroup(badgegroupId: string): Promise<any> {
  const response = await fetch(ENDPOINTS.BADGEGROUPS + badgegroupId + "/Students", {
    method: "GET",
    headers: {
      ...jsonHeaders,
      Authorization: "Bearer " + getAccessToken(),
    },
    credentials: "include",
  });

  if (!response.ok) {
    throw new Error("Error fetching students");
  }

  return response.json();
}
