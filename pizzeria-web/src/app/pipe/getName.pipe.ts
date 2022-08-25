import { Pipe, PipeTransform } from "@angular/core";

@Pipe({ name: 'GetName' })
export class GetNamePipe  implements PipeTransform {
  transform(array: any): string {
    if (!array?.length) {
      return '';
    }
    let added =  array.filter((k: any) => k.IsAdded)
    if(added.length) return added.map((k: any) => k.Name).join();
    else return '';
  }
}