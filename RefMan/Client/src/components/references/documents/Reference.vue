<template lang="pug">
.flex.my-5
  .flex.flex-col.justify-end.mr-3
    c-font-awesome-button.my-1(icon="edit" @click="toggleEdit")
    c-font-awesome-button.my-1(icon="times" @click="deleteReference")
    a(:href="reference.url" target="_blank")
      c-font-awesome-button.my-1(icon="external-link-alt")
  article.flex.flex-col.items-center.text-sm
    figure
      img(
        :src="reference.iconUrl"
        alt=""
        height="25"
        width="25"
      )
    h2 {{ reference.webpageTitle }}
    div
      c-citation(title="In-text:")
        | ({{ reference.webpageTitle }}, {{ publishYear }})
      c-citation(title="Bibliography:")
        | {{ reference.websiteName }}.
        | ({{ publishYear }}).
        | {{ reference.webpageTitle }}.
        | [online]
        | Available at: {{ reference.url }}
        | [Accessed {{ accessDateReferenceFormat }}].
</template>

<script>
import { library } from "@fortawesome/fontawesome-svg-core";
import { faEdit, faTimes, faExternalLinkAlt } from "@fortawesome/free-solid-svg-icons";
import FontAwesomeButtonComponent from "@/components/shared/buttons/FontAwesomeButton";
import CitationComponent from "@/components/references/documents/Citation";
import { Reference } from "@/models/referencing/Reference";

library.add(faEdit);
library.add(faTimes);
library.add(faExternalLinkAlt);

export default {
  components: {
    "c-font-awesome-button": FontAwesomeButtonComponent,
    "c-citation": CitationComponent
  },
  props: {
    reference: Reference
  },
  computed: {
    publishYear() {
      const publishYear = this.reference.publishYear;
      return publishYear === null ? "n.d." : publishYear;
    },
    accessDateReferenceFormat() {
      const date = this.reference.accessDate;

      const day = date.getDate();
      const monthIndex = date.getMonth();
      const year = date.getFullYear();

      const monthString = [
        "January",
        "February",
        "March",
        "April",
        "May",
        "June",
        "July",
        "August",
        "September",
        "October",
        "November",
        "December"
      ][monthIndex];
      const monthThreeLetters = monthString.substring(0, 3);

      const yearLastTwoDigits = year % 100;

      return `${day} ${monthThreeLetters}. ${yearLastTwoDigits}`;
    }
  },
  methods: {
    toggleEdit() {
    },
    deleteReference() {
    }
  }
};
</script>