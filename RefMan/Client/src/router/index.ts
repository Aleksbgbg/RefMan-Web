import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import MainComponent from "@/components/Main.vue";

Vue.use(VueRouter);

const routes: RouteConfig[] = [
  {
    path: "/",
    component: MainComponent,
    children: [
      {
        name: "references",
        path: "/references",
        component: () => import("@/components/references/References.vue")
      },
      {
        name: "login",
        path: "/login",
        component: () => import("@/components/auth/Login.vue")
      },
      {
        name: "register",
        path: "/register",
        component: () => import("@/components/auth/Register.vue")
      },
      {
        path: "/",
        redirect: "references"
      }
    ]
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes
});

export default router;